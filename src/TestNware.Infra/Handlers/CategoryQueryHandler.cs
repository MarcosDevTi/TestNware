using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestNware.Domain.Commands;
using TestNware.Domain.Contracts;
using TestNware.Domain.Models;
using TestNware.Domain.Pagination;
using TestNware.Domain.Queries;
using TestNware.Domain.Queries.Models;
using TestNware.Infra.Data;
using TestNware.Infra.Extensions;

namespace TestNware.Infra.Handlers
{
    public class CategoryQueryHandler :
        IQueryHandler<GetCategoryForEdition, EditCategory>,
        IQueryHandler<GetCategories, PagedResult<Category>>,
        IQueryHandler<GetPostByCategory, IEnumerable<Post>>,
        IQueryHandler<GetCategory, Category>,
        IQueryHandler<GetCategoriesForDropdownList, IEnumerable<CategoryItem>>
    {
        private readonly NWareContext _context;

        public CategoryQueryHandler(NWareContext context)
        {
            _context = context;
        }
        public async Task<EditCategory> Handle(GetCategoryForEdition query)
        {
            var categoryData = await _context.Categories.FindAsync(query.Id);
            return new EditCategory
            {
                Id = categoryData.Id,
                Title = categoryData.Title
            };
        }

        public async Task<PagedResult<Category>> Handle(GetCategories query)
        {
            return await _context.Categories
                   .GetPagedResult(
                      new Paging<Category>
                      {
                          Skip = query.Skip,
                          Top = query.Top
                      });
        }

        public async Task<IEnumerable<Post>> Handle(GetPostByCategory query)
        {
            return await _context.Posts
                .Where(p => p.CategoryId == query.CategoryId)
                .ToListAsync();
        }

        public async Task<Category> Handle(GetCategory query)
        {
            return await _context.Categories.FindAsync(query.Id);
        }

        public async Task<IEnumerable<CategoryItem>> Handle(GetCategoriesForDropdownList query)
        {
            return await _context.Categories
                .OrderBy(c => c.Title)
                .Select(c =>
                            new CategoryItem
                            {
                                Id = c.Id,
                                Title = c.Title
                            }).ToListAsync();
        }
    }
}
