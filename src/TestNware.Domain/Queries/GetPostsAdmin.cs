using TestNware.Domain.Contracts;
using TestNware.Domain.Pagination;
using TestNware.Domain.Queries.Models;

namespace TestNware.Domain.Queries
{
    public class GetPostsAdmin : IQuery<PagedResult<PostItemAdmin>>
    {
        public int? Skip { get; set; }

        public int? Top { get; set; }
    }
}
