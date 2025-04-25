using Api.DTOs;

namespace Api.Services
{
    public interface IProductService
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <param name="page">Start page</param>
        /// <param name="pageSize">End page</param>
        /// <returns>List of products</returns>
        Task<List<ProductListDto>> GetProductsAsync(int page, int pageSize);
        
        /// <summary>
        /// Get details of the product by its ID
        /// </summary>
        /// <param name="id">ID of the product</param>
        /// <returns>Details of the product</returns>
        Task<ProductDetailDto> GetProductDetailsAsync(int id);

        /// <summary>
        /// Add a product into the Database
        /// </summary>
        /// <param name="dto">A product to add</param>
        /// <returns>Added product</returns>
        Task<ProductDetailDto> AddProductAsync(ProductCreateDto dto);
    }
}
