using TestNware.Domain.Contracts;
using TestNware.Domain.Models;
using TestNware.Domain.Pagination;

namespace TestNware.Domain.Queries
{
    public class GetCategories : IQuery<PagedResult<Category>>
    {
        public int? Skip { get; set; }

        public int? Top { get; set; }
    }
}
