using AutoMapper;
using ECommerceAPI.DataBase.Models;
using ECommerceAPI.DataBase.Repositories;
using ECommerceAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IRepository<Product> _giftRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper,IRepository<Product> giftRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _giftRepository = giftRepository;
    }

    public async Task AddProductAsync(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.AddProductAsync(product);
    }

    public async Task DeleteProductAsync(int id)
    {
        await _productRepository.DeleteProductAsync(id);
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllProductsAsync();
        var s= await _giftRepository.GetAll().ToListAsync();

        return _mapper.Map<IEnumerable<ProductDto>>(products);
    }   

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        return product == null ? null : _mapper.Map<ProductDto>(product);     throw new NotImplementedException();
    }

    public async Task UpdateProductAsync(ProductDto productDto)
    {
        var product = await _productRepository.GetProductByIdAsync(productDto.Id);
        if (product != null)
        {
             _mapper.Map(productDto, product);
             await _productRepository.UpdateProductAsync(product);
        }
    }
}