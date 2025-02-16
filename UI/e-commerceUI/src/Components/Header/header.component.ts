import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject } from "rxjs";
import { AuthService } from "../../services/AuthService";

@Component({
    selector:"app-header",
    standalone:false,
    templateUrl:"./header.component.html",
    styleUrls: ["./header.component.css"]
})

export class HeaderComponent implements OnInit {
    user: any = null;

    constructor(private http: HttpClient, 
        private authService:AuthService,
        private router: Router) {}
  
    ngOnInit(): void {
        this.authService.authStatus$.subscribe((isLoggedIn) => {
            if (isLoggedIn) {
              this.getUserInfo();
            } else {
              this.user = null;
            }
          });
      
          this.getUserInfo();

    }
   
  
    getUserInfo(): void {
        console.log("call cme")
      this.http.get('http://localhost:5142/api/auth/user').subscribe({
        next: (data: any) => {
          this.user = data;
          console.log("userinfo",this.user)
        },
        error: () => {
          this.user = null;
        }
      });
    }
  
    logout(): void {
      localStorage.removeItem('token');
      localStorage.removeItem('userId');
      this.router.navigate(['/login']); // Redirect to login page
    }
  }