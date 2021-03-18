using TestNware.Domain.Models;
using TestNware.Domain.Pagination;

namespace TestNware.Domain.Queries.Models
{
    public class HomePageResult
    {
        public PagedResult<Category> Categories { get; set; }
        public PagedResult<Post> Posts { get; set; }
    }
}
