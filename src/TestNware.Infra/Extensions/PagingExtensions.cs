using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNware.Domain.Pagination;

namespace TestNware.Infra.Extensions
{
    public static class PagingExtensions
    {
        public static async Task<PagedResult<T>> GetPagedResult<T>(this IQueryable<T> query, Paging<T> paging)
        {
            var list = await
                query.Skip(paging.Skip).Take(paging.Top).ToListAsync();
            var count = await query.CountAsync();
            return new PagedResult<T>(list, count, paging);
        }
            
    }
}
