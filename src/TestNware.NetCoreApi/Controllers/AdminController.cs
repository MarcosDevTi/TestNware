using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestNware.API.Controllers;
using TestNware.Domain.Contracts;
using TestNware.Domain.Queries;

namespace TestNware.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseController
    {
        public AdminController(IProcessor processor) : base(processor) { }

        [HttpGet("categories-admin")]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategories categories) =>
            await GetListResultPaged(categories);

        [HttpGet("posts-admin")]
        public async Task<IActionResult> GetPosts([FromQuery] GetPostsAdmin posts) =>
            await GetListResultPaged(posts);
    }

}
