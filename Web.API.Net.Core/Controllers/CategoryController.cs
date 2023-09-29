using Api.Controllers.Abstract;
using Domain.Dtos.Admin;
using Microsoft.AspNetCore.Mvc;
using Services.Admin;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) =>
            _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            ApiOk(await _categoryService.List());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) =>
            ApiOk(await _categoryService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDTO category) =>
            ApiOk(await _categoryService.Create(category));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CategoryDTO category) =>
            ApiOk(await _categoryService.Update(id, category));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) =>
            ApiOk(await _categoryService.Delete(id));
    }
}
