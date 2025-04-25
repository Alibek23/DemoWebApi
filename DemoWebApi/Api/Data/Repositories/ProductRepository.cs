using Api.DTOs;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductListDto>> GetProductsAsync(int page, int pageSize)
        {
            return await _context.Products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new ProductListDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName
                }).ToListAsync();
        }

        public async Task<ProductDetailDto> GetProductDetailsAsync(int id)
        {
            return await _context.Products
                .Where(p => p.ProductId == id)
                .Select(p => new ProductDetailDto
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice,
                    CategoryName = p.Category.CategoryName,
                    CategoryDescription = p.Category.Description,
                    SupplierName = p.Supplier.CompanyName
                }).FirstOrDefaultAsync();
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
