import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { LoginDto } from '../Dtos/loginDto';
import { AuthResponseDto } from '../Dtos/AuthResponseDto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5142/api/auth'; // Replace with your API
  private authLoginStatusSubject = new BehaviorSubject<boolean>(this.hasToken()); // Check if token exists
  authStatus$ = this.authLoginStatusSubject.asObservable();

  constructor(private http: HttpClient) {}

  login(loginData:LoginDto): Observable<AuthResponseDto> {
    return this.http.post<AuthResponseDto>(`${this.apiUrl}/login`, 
        { email:loginData.email, 
        password:loginData.password });
  }
  refreshToken(): Observable<AuthResponseDto> {
    const refreshToken = localStorage.getItem('refreshToken');
    return this.http.post<AuthResponseDto>(`${this.apiUrl}/refresh`, {
      userId: localStorage.getItem("userId"),
      email:"shaikhsa7lim@gmail.com",
      refreshToken:localStorage.getItem("refreshToken")
     });
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }
  private hasToken(): boolean {
    return !!localStorage.getItem('token');
  }
  
  setToken(userData:AuthResponseDto): void {
    localStorage.setItem('token',userData.token);
    localStorage.setItem('refreshToken',userData.refreshToken);
    localStorage.setItem("userId",userData.userId);
    this.authLoginStatusSubject.next(true); // Notify that user is logged in
  }
  logout() {
    let userId= localStorage.getItem("userId");
    localStorage.removeItem('token');
    localStorage.removeItem('refreshToken');
    localStorage.removeItem("userId");
    this.authLoginStatusSubject.next(false); // Notify that user is logged in

    return this.http.post<any>(`${this.apiUrl}/logout`, 
      { userId:userId });
  }
}
