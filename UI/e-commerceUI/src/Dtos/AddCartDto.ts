export interface AddCartDto
{
    userId?:string | null,
    productId:number,
    quantity:number
}