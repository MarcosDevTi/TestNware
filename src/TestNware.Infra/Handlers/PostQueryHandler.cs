using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestNware.Domain.Commands;
using TestNware.Domain.Contracts;
using TestNware.Domain.Models;
using TestNware.Domain.Pagination;
using TestNware.Domain.Queries;
using TestNware.Infra.Data;
using TestNware.Infra.Extensions;

namespace TestNware.Infra.Handlers
{
    public class PostQueryHandler :
        IQueryHandler<GetPostForEdition, EditPost>,
        IQueryHandler<GetPosts, PagedResult<Post>>,
        IQueryHandler<GetPost, Post>
    {
        private readonly NWareContext _context;

        public PostQueryHandler(NWareContext context)
        {
            _context = context;
        }
        public async Task<EditPost> Handle(GetPostForEdition query)
        {
            var post = await _context.Posts
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == query.Id);

            return new EditPost
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.Category.Id,
                PublicationDate = post.PublicationDate
            };
        }

        public async Task<PagedResult<Post>> Handle(GetPosts query)
        {
            return await _context.Posts
                .Where(p => p.PublicationDate.Date <= DateTime.Now.Date)
                .OrderByDescending(p => p.PublicationDate)
                .Include(c => c.Category)
                    .GetPagedResult(
                       new Paging<Post>
                       {
                           Skip = query.Skip,
                           Top = query.Top
                       });
        }

        public async Task<Post> Handle(GetPost query)
        {
            return await _context.Posts.FindAsync(query.Id); ;
        }
    }
}
