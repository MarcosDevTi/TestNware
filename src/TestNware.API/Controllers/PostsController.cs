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
    public class PostsController : Controller
    {
        private readonly IProcessor _processor;

        public PostsController(IProcessor processor)
        {
            _processor = processor;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetPosts posts)
        {
            var result = await _processor.Get(posts);

            if (result.Items.Any())
                return Ok(result);
            return NoContent();
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _processor.Get(new GetPost(id));
            if (result is null)
                return NotFound(result);
            return Ok(result);
        }


    }
}
