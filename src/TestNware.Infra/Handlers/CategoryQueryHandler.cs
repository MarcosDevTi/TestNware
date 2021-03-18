﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        IQueryHandler<GetCategoryForEdition, CategoryForEdition>,
        IQueryHandler<GetCategories, PagedResult<Category>>,
        IQueryHandler<GetPostByCategory, IEnumerable<Post>>,
        IQueryHandler<GetCategory, Category>
    {
        private readonly NWareContext _context;

        public CategoryQueryHandler(NWareContext context)
        {
            _context = context;
        }
        public async Task<CategoryForEdition> Handle(GetCategoryForEdition query)
        {
            var categoryData = await _context.Categories.FindAsync(query.Id);
            return new CategoryForEdition
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
    }
}