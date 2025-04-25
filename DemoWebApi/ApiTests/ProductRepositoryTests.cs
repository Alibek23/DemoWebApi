using Api.DTOs;
using Api.Models;
using Api.Data.Repositories;
using Moq;
using Api.Services;
using TestRec = ApiTests.TestData.ProductTestRecords;

namespace ApiTests
{
    // Tests/ProductServiceTests.cs
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _service = new ProductService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetProductsAsync_ReturnsPagedList()
        {
            _mockRepo.Setup(repo => repo.GetProductsAsync(1, 2))
                .ReturnsAsync(TestRec.ProductListDto);

            var result = await _service.GetProductsAsync(1, 2);

            Assert.Equal(2, result.Count);
            Assert.Contains(result, p => p.ProductName == "Test 1");
        }

        [Fact]
        public async Task AddProductAsync_CreatesProduct()
        {
            _mockRepo.Setup(r => r.AddProductAsync(It.IsAny<Product>())).ReturnsAsync(TestRec.CreatedProduct);
            _mockRepo.Setup(r => r.GetProductDetailsAsync(10)).ReturnsAsync(new ProductDetailDto
            {
                ProductId = 10,
                ProductName = TestRec.ProductCreateDto.ProductName,
                UnitPrice = TestRec.ProductCreateDto.UnitPrice,
                CategoryName = "Cat",
                CategoryDescription = "Desc",
                SupplierName = "Supplier"
            });

            var result = await _service.AddProductAsync(TestRec.ProductCreateDto);

            Assert.Equal(TestRec.NewProductName, result.ProductName);
            Assert.Equal(10, result.ProductId);
        }
    }

}
