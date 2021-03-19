using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestNware.API.Controllers;
using TestNware.Domain.Contracts;
using TestNware.Domain.Queries;

namespace TestNware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : BaseController
    {
        public PostsController(IProcessor processor) : base(processor) { }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetPosts posts) =>
            await GetListResultPaged(posts);

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id) =>
            await GetFirstOrNotFound(new GetPost(id));
    }
}
