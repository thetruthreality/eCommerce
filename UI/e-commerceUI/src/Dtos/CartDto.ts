import { CartItemDto } from "./CartItemDto";

export interface CartDto{
    id: number;
  userId: string;
  cartItems: CartItemDto[];
  totalPrice: number;
}