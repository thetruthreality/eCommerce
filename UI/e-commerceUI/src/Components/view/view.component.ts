import { Component, OnInit } from "@angular/core";
import { ProductDto } from "../../Dtos/ProductDto";
import { ProductService } from "../../services/ProductService";
import { Router } from "@angular/router";

@Component({
  selector: 'app-view',
  standalone: false,
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})

export class ViewComponent implements OnInit {
  products: ProductDto[] = [];
  errorMessage: string = '';

  constructor(private productService: ProductService,
    private router: Router) {

  }
  ngOnInit(): void {
    this.loadProducts();
  }
  loadProducts(): void {
    this.productService.getAllProducts().subscribe({
      next: (data) => {
        this.products = data;
        this.errorMessage = '';
      },
      error: (err) => {
        this.errorMessage = 'Failed to load products. Please try again later.';
        console.error('Error fetching products:', err);
      }
    });
  }

  viewProductDetails(product: any) {
    this.router.navigate(["/product-details", product.id]);
  }
}