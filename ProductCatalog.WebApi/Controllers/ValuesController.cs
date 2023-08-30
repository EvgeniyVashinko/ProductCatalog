using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Core.Entities;
using ProductCatalog.Core.Repositories;
using ProductCatalog.Core.Requests;
using ProductCatalog.Core.Requests.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductCatalog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICategoryRepository repo;

        public ValuesController(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await repo.GetCategoriesAsync());
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            await repo.AddAsync(new Category()
            {
                Name = request.Name,
            });

            await repo.SaveChangesAsync();

            return Ok();
        }
    }
}
