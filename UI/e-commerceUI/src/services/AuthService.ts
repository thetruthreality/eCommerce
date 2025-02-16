import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginDto } from '../Dtos/loginDto';

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

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  logout() {
    localStorage.removeItem('token');
  }
}
