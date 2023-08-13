using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Solisystems.Domain.Entities;
using Solisystems.Services.Interfaces;

namespace Solisystems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductEntityController : ControllerBase
    {
        private readonly IProductEntityService _productEntityService;
        public ProductEntityController(IProductEntityService productEntityService)
        {
            _productEntityService = productEntityService;
        }

        //http://localhost:5059/api/ProductEntity/?filter=productEntityName="Electronics"
        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] int pageSize = 5000,
            [FromQuery] int pageNumber = 1,
            [FromQuery] string? filter = null,
            [FromQuery] string? orderBy = null)
        {
            var result = await _productEntityService.GetAllProductEntities(filter ?? "", orderBy ?? "");

            var data = result is IList<ProductEntity> productEntityList ? productEntityList : result.ToList();
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
            var result = await _productEntityService.GetProductEntityById(id);
            if (result == null)
                return NotFound();  // 404 Not Found
            return Ok(result);  // 200 OK
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductEntity productEntity)
        {
            var isSuccess = await _productEntityService.CreateProductEntity(productEntity);
            if (!isSuccess)
                return BadRequest();  // 400 Bad Request
            return CreatedAtAction(nameof(Get), new { id = productEntity.ProductCode }, productEntity);  // 201 Created
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductEntity productEntity)
        {
            var isSuccess = await _productEntityService.UpdateProductEntity(productEntity);
            if (!isSuccess)
                return BadRequest();  // 400 Bad Request
            return NoContent();  // 204 No Content
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(string id)
        {
            var isSuccess = await _productEntityService.DeleteProductEntity(id);
            if (!isSuccess)
                return BadRequest();  // 400 Bad Request
            return NoContent();  // 204 No Content
        }
    }
}
