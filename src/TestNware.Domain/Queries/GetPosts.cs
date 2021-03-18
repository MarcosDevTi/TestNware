using TestNware.Domain.Contracts;
using TestNware.Domain.Models;
using TestNware.Domain.Pagination;

namespace TestNware.Domain.Queries
{
    public class GetPosts : IQuery<PagedResult<Post>>
    {
        public int? Skip { get; set; }

        public int? Top { get; set; }
    }
}
