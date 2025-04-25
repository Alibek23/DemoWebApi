using Api.DTOs;
using Api.Models;

namespace ApiTests.TestData
{
    internal static class ProductTestRecords
    {
        internal static readonly string NewProductName = "New Product";

        internal static readonly Product[] TestProducts =
        [
            new Product { ProductId = 1, ProductName = "Chai" },
            new Product { ProductId = 2, ProductName = "Chang" }
        ];

        internal static readonly List<ProductListDto> ProductListDto = new()
        {
            new ProductListDto { ProductId = 1, ProductName = "Test 1" },
            new ProductListDto { ProductId = 2, ProductName = "Test 2" }
        };

        internal static readonly ProductCreateDto ProductCreateDto = new()
        {
            ProductName = NewProductName,
            CategoryId = 1,
            SupplierId = 1,
            UnitPrice = 9.99m
        };

        internal static readonly Product CreatedProduct = new Product
        {
            ProductId = 10,
            ProductName = ProductCreateDto.ProductName,
            CategoryId = ProductCreateDto.CategoryId,
            SupplierId = ProductCreateDto.SupplierId,
            UnitPrice = ProductCreateDto.UnitPrice,
            Discontinued = false
        };
    }
}
