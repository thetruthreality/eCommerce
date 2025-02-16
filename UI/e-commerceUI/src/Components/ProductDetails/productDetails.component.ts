import { HttpClient } from "@angular/common/http";
import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ProductService } from "../../services/ProductService";
import { CartService } from "../../services/CartService";
import { AddCartDto } from "../../Dtos/AddCartDto";

@Component({
    selector:"product-details",
    standalone:false,
    templateUrl:'./productDetails.component.html',
    styleUrls:['./productDetails.componetn.css']
})
export class ProductDetailsComponent{
    product: any;
  quantity: number = 1;// Assume logged-in user ID

  constructor(private route: ActivatedRoute,
    private productService: ProductService,
    private cartService: CartService) {}

  ngOnInit(): void {
    const productId = this.route.snapshot.paramMap.get("id");
    this.getProductDetails(productId);
  }

  getProductDetails(productId: string | null) {
    // Call API to fetch product details
    this.productService.getProductById(productId).subscribe((data: any) => {
        this.product = data;
        console.log(this.product);
      });
  }

  increaseQuantity() {
    console.log("incres");
    if (this.quantity < this.product.stockQuantity) {
      this.quantity+=1;
    }
  }

  decreaseQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }

  }

  addToCart() {
    const cartItem: AddCartDto={
      userId: "",
      productId: this.product.id,
      quantity: this.quantity
    };
    cartItem.userId = localStorage.getItem("userId") || null;
    this.cartService.addToCart(cartItem).subscribe((data: any) => {
      console.log("suucess");
    });

    // Call Add to Cart API
    // this.http.post("http://localhost:5000/api/cart", cartItem).subscribe(response => {
    //   alert("Product added to cart successfully!");
    // });
  }
}