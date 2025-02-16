import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginDto } from '../Dtos/loginDto';
import { AuthResponseDto } from '../Dtos/AuthResponseDto';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5142/api/auth'; // Replace with your API
  constructor(private http: HttpClient) {}

  login(loginData:LoginDto): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, 
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

  logout() {
    let userId= localStorage.getItem("userId");
    localStorage.removeItem('token');
    localStorage.removeItem('refreshToken');
    localStorage.removeItem("userId");
    return this.http.post<any>(`${this.apiUrl}/logout`, 
      { userId:userId });
  }
}
