using System;
using System.Collections.Generic;
using System.Text;
using TestNware.Domain.Contracts;
using TestNware.Domain.Models;
using TestNware.Domain.Pagination;

namespace TestNware.Domain.Queries
{
    public class GetCategoriesAdmin : IQuery<PagedResult<Category>>
    {
        public int Skip { get; set; }

        public int Top { get; set; }
    }
}
