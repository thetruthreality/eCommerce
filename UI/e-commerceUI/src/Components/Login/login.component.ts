import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/AuthService';
import { LoginDto } from '../../Dtos/loginDto';

@Component({
  selector: 'app-login',
  standalone:false,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
    loginData: LoginDto = { email: '', password: '' };
  constructor(private authService: AuthService, private router: Router) {}

  login() {
    console.log("apicall")
    this.authService.login(this.loginData).subscribe(response => {

      if (response.token) {

       this.authService.setToken(response)
        this.router.navigate(['/views']); // Redirect to view page
      }
    }, error => {
      alert('Invalid Credentials');
    });
  }
}
