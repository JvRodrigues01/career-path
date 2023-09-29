using Api.Controllers.Abstract;
using Domain.Dtos.Admin;
using Microsoft.AspNetCore.Mvc;
using Services.Admin;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) =>
            _productService = productService;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            ApiOk(await _productService.List());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) =>
            ApiOk(await _productService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDTO product) =>
            ApiOk(await _productService.Create(product));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductDTO product) =>
            ApiOk(await _productService.Update(id, product));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) =>
            ApiOk(await _productService.Delete(id));
    }
}
