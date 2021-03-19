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
    public class CategoriesController : BaseController
    {
        public CategoriesController(IProcessor processor)
            : base(processor) { }

        [HttpGet]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategories categories) =>
            await GetListResultPaged(categories);

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetCategory(Guid id) =>
            await GetFirstOrNotFound(new GetCategory(id));


        [HttpGet("{id:guid}/posts")]
        public async Task<IActionResult> GetPosts(Guid id) =>
            await GetListResult(new GetPostByCategory(id));
    }
}