﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestNware.API.Controllers;
using TestNware.Domain.Contracts;
using TestNware.Domain.Queries;

namespace TestNware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseController
    {
        public AdminController(IProcessor processor) : base(processor) { }

        [HttpGet, Route("categories-admin")]
        public async Task<IActionResult> GetCategories([FromQuery] GetCategories categories) =>
            await GetListResultPaged(categories);

        [HttpGet, Route("posts-admin")]
        public async Task<IActionResult> GetAsync([FromQuery] GetPostsAdmin posts) =>
            await GetListResultPaged(posts);
    }

}
