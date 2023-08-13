using Microsoft.AspNetCore.Mvc;
using Solisystems.Domain.Entities;
using Solisystems.Services;
using Solisystems.Services.Interfaces;

namespace Solisystems.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        //http://localhost:5059/api/Category/?filter=categoryName="Electronics"
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] int pageSize = 5000,
            [FromQuery] int pageNumber = 1,
            [FromQuery] string? filter = null,
            [FromQuery] string? orderBy = null)
        {
            var result = await _categoryService.GetAllCategories(filter ?? "", orderBy ?? "");

            var data = result is IList<Category> categoryList ? categoryList : result.ToList();
            var totalCount = data.Count();
            var totalPages = Math.Ceiling((double)totalCount / pageSize);

            var pagedData = data
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var results = new
            {
                TotalCount = totalCount,
                totalPages,
                result = pagedData
            };

            return Ok(results);  // 200 OK
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _categoryService.GetCategoryById(id);
            if (result == null)
                return NotFound();  // 404 Not Found
            return Ok(result);  // 200 OK
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            var isSuccess = await _categoryService.CreateCategory(category);
            if (!isSuccess)
                return BadRequest();  // 400 Bad Request
            return CreatedAtAction(nameof(Get), new { id = category.CategoryCode }, category);  // 201 Created
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(string id, [FromBody] Category category)
        {
            var isSuccess = await _categoryService.UpdateCategory(category);
            if (!isSuccess)
                return BadRequest();  // 400 Bad Request
            return NoContent();  // 204 No Content
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(string id)
        {
            var isSuccess = await _categoryService.DeleteCategory(id);
            if (!isSuccess)
                return BadRequest();  // 400 Bad Request
            return NoContent();  // 204 No Content
        }
    }

}
