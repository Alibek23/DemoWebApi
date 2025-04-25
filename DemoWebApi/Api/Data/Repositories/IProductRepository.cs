using Api.DTOs;
using Api.Models;

namespace Api.Data.Repositories
{
    public interface IProductRepository
    {
        Task<List<ProductListDto>> GetProductsAsync(int page, int pageSize);
        Task<ProductDetailDto> GetProductDetailsAsync(int id);
        Task<Product> AddProductAsync(Product product);
    }
}
