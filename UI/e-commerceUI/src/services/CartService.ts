import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { AddCartDto } from "../Dtos/AddCartDto";

@Injectable({
  providedIn: "root", // Makes it available throughout the app
})
export class CartService {
  private baseUrl = "http://localhost:5142/api/Cart"; // Change based on your API

  constructor(private http: HttpClient) {}

  // ✅ Add product to cart
  addToCart(Addcart:AddCartDto): Observable<any> {
    return this.http.post(`${this.baseUrl}/add`, {
        userId: Addcart.userId,
        quantity:Addcart.quantity,
        productId:Addcart.productId
    })
  }

  // ✅ Get cart items by user ID
  getCartItems(userId: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/${userId}`);
  }

  // ✅ Remove item from cart
  removeFromCart(cartItemId: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${cartItemId}`);
  }
}
