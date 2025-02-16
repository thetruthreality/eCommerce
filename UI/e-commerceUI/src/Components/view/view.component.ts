import { Component } from "@angular/core";
import { ProductDto } from "../../Dtos/ProductDto";
import { ProductService } from "../../services/ProductService";
import { Router } from "@angular/router";

@Component({
    selector:'app-view',
    standalone:false,
    templateUrl:'./view.component.html',
    styleUrls:['./view.component.css']
})

export class ViewComponent{
    products: ProductDto[] = [];
    constructor(private productService: ProductService,
        private router: Router)
    {
        
    }
    ngOnInit(): void {
        this.loadProducts();
      }
      loadProducts(): void {
        this.productService.getAllProducts().subscribe({
          next: (data) => {
            this.products = data;
          },
          error: (err) => {
            console.error('Error fetching products:', err);
          }
        });
      }

      viewProductDetails(product: any) {
        this.router.navigate(["/product-details", product.id]);
      }
}