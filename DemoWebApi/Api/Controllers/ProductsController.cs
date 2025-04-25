using Api.DTOs;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _service;

        public ProductsController(IProductService service, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductListDto>>> GetProducts(int page = 1, int pageSize = 10)
        {
            return Ok(await _service.GetProductsAsync(page, pageSize));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailDto>> GetProduct(int id)
        {
            var product = await _service.GetProductDetailsAsync(id);
            if (product == null) 
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto dto)
        {
            var created = await _service.AddProductAsync(dto);
            return CreatedAtAction(nameof(GetProduct), new { id = created.ProductId }, created);
        }
    }
}
