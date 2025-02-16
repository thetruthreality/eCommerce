export interface CartItemDto
{
    id: number;
    productId: number;
    quantity: number;
    productName: string;
    price: number;
    imageUrl: string,
    totalPrice: number;
}