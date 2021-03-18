using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestNware.Domain.Contracts;
using TestNware.Domain.Queries;

namespace TestNware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly IProcessor _processor;

        public CategoriesController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategories categories)
        {
            var result = await _processor.Get(categories);

            if (result.Items.Any())
                return Ok(result);
            return NoContent();
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var result = await _processor.Get(new GetCategory(id));

            if (result is null)
                return NotFound(result);
            return Ok(result);
        }

        [Route("{id:guid}/posts")]
        [HttpGet]
        public async Task<IActionResult> GetPosts(Guid id)
        {
            var result = await _processor.Get(new GetPostByCategory(id));

            if (result.Any())
                return Ok(result);
            return NoContent();
        }
    }
}