using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TestNware.Domain.Contracts;
using TestNware.Domain.Pagination;
using TestNware.Domain.Queries;
using TestNware.Domain.Queries.Models;
using TestNware.Infra.Data;

namespace TestNware.Infra.Handlers
{
    public class AdminQueryHandler :
        IQueryHandler<GetPostsAdmin, PagedResult<PostItemAdmin>>
    {
        private readonly NWareContext _context;

        public AdminQueryHandler(NWareContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<PostItemAdmin>> Handle(GetPostsAdmin query)
        {
            var postsAdmin = await _context.Posts.OrderByDescending(p => p.CreatedDate)
               .Skip(query.Skip.Value)
               .Take(query.Top.Value)
               .Select(p => new PostItemAdmin
               {
                   Id = p.Id,
                   Title = p.Title
               }
                   ).ToListAsync();

            var count = await _context.Posts.CountAsync();
            var paging = new Paging<PostItemAdmin>
            {
                Skip = query.Skip.Value,
                Top = query.Top.Value
            };

            return new PagedResult<PostItemAdmin>(postsAdmin, count, paging);
        }
    }
}
