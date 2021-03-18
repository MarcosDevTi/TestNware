using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TestNware.Domain.Contracts;
using TestNware.Domain.Queries;

namespace TestNware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IProcessor _processor;

        public AdminController(IProcessor processor)
        {
            _processor = processor;
        }

        [Route("categories-admin")]
        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategories categories)
        {
            var result = await _processor.Get(categories);

            if (result.Items.Any())
                return Ok(result);
            return NoContent();
        }

        [Route("posts-admin")]
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetPostsAdmin posts)
        {
            var result = await _processor.Get(posts);

            if (result.Items.Any())
                return Ok(result);
            return NoContent();
        }
    }

}
