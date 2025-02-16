import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpErrorResponse, HttpEvent } from '@angular/common/http';
import { BehaviorSubject, catchError, filter, Observable, switchMap, take, throwError } from 'rxjs';
import { AuthService } from './AuthService';
import { AuthResponseDto } from '../Dtos/AuthResponseDto';
import { Router } from '@angular/router';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  private isRefreshing = false;
  private refreshTokenSubject: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(null);
  constructor(private authService: AuthService,
    private router: Router
  ) {}

  intercept(req: HttpRequest<any>, next: HttpHandler)
  {
    const token = localStorage.getItem('token');
    let authReq = req;
    if (token) {
      authReq = this.addToken(req, token);
    }
    
    return next.handle(authReq).pipe(
      catchError((error:HttpErrorResponse)=>{
        if(error.status ==401)
        {
          if (req.url.includes('/api/auth/user')) {
            console.warn('User info API failed, skipping refresh token.');
            return throwError(() => error);
          }
          return this.handle401Error(authReq,next)
        }
        return throwError(() => error);
      })
    );
  }
  private handle401Error(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!this.isRefreshing) {
      this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      return this.authService.refreshToken().pipe(
        switchMap((response:AuthResponseDto) => {
          this.isRefreshing = false;

          // Update token and refresh token in localStorage
          localStorage.setItem('token', response.token);
          localStorage.setItem('refreshToken', response.refreshToken);
      
          // Notify subscribers that a new token is available
          this.refreshTokenSubject.next(response.token);
      
          // Retry the original failed request with the new token
          return next.handle(this.addToken(req,response.token));
        }),
        catchError((err) => {
          this.isRefreshing = false;
          this.authService.logout(); // Logout user if refresh fails
          this.router.navigate(['/login']);
          return throwError(() => err);
        })
      );
    } else {
      return this.refreshTokenSubject.pipe(
        filter((token) => token !== null),
        take(1),
        switchMap((token) => next.handle(this.addToken(req, token!)))
      );
    }
  }

  private addToken(req: HttpRequest<any>, token: string) {
    return req.clone({ setHeaders: { Authorization: `Bearer ${token}` } });
  }
}
