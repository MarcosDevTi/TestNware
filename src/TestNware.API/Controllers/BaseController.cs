using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNware.Domain.Contracts;
using TestNware.Domain.Pagination;

namespace TestNware.API.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IProcessor _processor;

        public BaseController(IProcessor processor)
        {
            _processor = processor;
        }

        public async Task<IActionResult> GetListResultPaged<T>(IQuery<PagedResult<T>> get)
        {
            var result = await _processor.Get(get);
            if (result.Items.Any())
                return Ok(result);
            return NoContent();
        }

        public async Task<IActionResult> GetListResult<T>(IQuery<IEnumerable<T>> getList)
        {
            var result = await _processor.Get(getList);
            if (result.Any())
                return Ok(result);
            return NoContent();
        }

        public async Task<IActionResult> GetFirst<T>(IQuery<T> query)
        {
            var result = await _processor.Get(query);

            if (result is null)
                return NotFound(result);
            return Ok(result);
        }
    }
}
