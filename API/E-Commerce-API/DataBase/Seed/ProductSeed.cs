using ECommerceAPI.Database;
using ECommerceAPI.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.DataBase.Seed;

public  static class ProductSeed
{
    public static void ProductsSeed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1, 
                    Name = "iPhone 15", 
                    Description = "Latest Apple iPhone", 
                    Price = 999.99m, 
                    StockQuantity = 50, 
                    ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-15-finish-select-202309-6-1inch_AV1?wid=940&hei=1112&fmt=jpeg&qlt=90&.v=1692912410763"
                },
                new Product 
                { 
                    Id = 2, 
                    Name = "Samsung Galaxy S23", 
                    Description = "Flagship Samsung phone", 
                    Price = 899.99m, 
                    StockQuantity = 40, 
                    ImageUrl = "https://images.samsung.com/is/image/samsung/p6pim/in/sm-s911bzeains/gallery/in-galaxy-s23-s911-446678-sm-s911bzeains-thumb-534613627?$172_172_PNG$"
                },
                new Product 
                { 
                    Id = 3, 
                    Name = "MacBook Pro", 
                    Description = "Apple MacBook Pro 16-inch", 
                    Price = 2499.99m, 
                    StockQuantity = 30, 
                    ImageUrl = "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mbp16-spacegray-select-202301?wid=800&hei=800&fmt=jpeg&qlt=90&.v=1671304673229"
                },
                new Product 
                { 
                    Id = 4, 
                    Name = "Dell XPS 15", 
                    Description = "Powerful Windows laptop", 
                    Price = 1999.99m, 
                    StockQuantity = 20, 
                    ImageUrl = "https://i.dell.com/sites/csimages/App-Merchandizing_Images/all/xps-15-9520-laptop-btp-app.png"
                },
                new Product 
                { 
                    Id = 5, 
                    Name = "Sony WH-1000XM5", 
                    Description = "Noise-canceling headphones", 
                    Price = 349.99m, 
                    StockQuantity = 100, 
                    ImageUrl = "https://m.media-amazon.com/images/I/61D4Z3yKPAL._AC_UF1000,1000_QL80_.jpg"
                }
            );
    }
}   

