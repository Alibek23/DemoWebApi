using Api.Data.Repositories;
using Api.DTOs;
using Api.Models;

namespace Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Task<List<ProductListDto>> GetProductsAsync(int page, int pageSize) =>
            _repository.GetProductsAsync(page, pageSize);

        public Task<ProductDetailDto> GetProductDetailsAsync(int id) =>
            _repository.GetProductDetailsAsync(id);

        public async Task<ProductDetailDto> AddProductAsync(ProductCreateDto dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                SupplierId = dto.SupplierId,
                CategoryId = dto.CategoryId,
                UnitPrice = dto.UnitPrice,
                Discontinued = false
            };

            var added = await _repository.AddProductAsync(product);
            return await _repository.GetProductDetailsAsync(added.ProductId);
        }
    }
}
