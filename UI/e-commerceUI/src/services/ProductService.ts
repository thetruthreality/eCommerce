import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductDto } from '../Dtos/ProductDto';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'http://localhost:5142/api/product'; // Replace with your actual API URL
  constructor(private http: HttpClient) {}

  getAllProducts(): Observable<ProductDto[]> {
    return this.http.get<ProductDto[]>(this.apiUrl);
  }
  getProductById(productId: string | null): Observable<ProductDto> {
    return this.http.get<ProductDto>(`${this.apiUrl}/${productId}`);
  }
}
