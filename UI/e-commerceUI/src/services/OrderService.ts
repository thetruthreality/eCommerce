import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root", // Makes it available throughout the app
})
export class OrderService {
  private baseUrl = "http://localhost:5142/api/order"; // Change based on your API

  constructor(private http: HttpClient) {}

 // ✅ Add product to cart
  addOrder(): Observable<any> {
    let userId= localStorage.getItem("userId");
    return  this.http.post<any>(`${this.baseUrl}/checkout/${userId}`,null)
  }
}