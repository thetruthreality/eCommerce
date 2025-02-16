import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/CartService';
import { CartDto } from '../../Dtos/CartDto';
import { OrderService } from '../../services/OrderService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone:false,
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class MyCartComponent implements OnInit {
  cart: CartDto | null = null;

  constructor(private cartService: CartService,
    private orderService: OrderService,
    private router: Router,
    
  ) {}

  ngOnInit(): void {
    this.loadCart();
  }

  loadCart(): void {
    this.cartService.getCartItems().subscribe((data: CartDto)=>{
        this.cart= data;
    });
  }

  buy(): void {
    // Add checkout logic here
    this.orderService.addOrder().subscribe(x=>{
        this.router.navigate(['/views']); 
    });
    console.log("done buy")
  }
}
