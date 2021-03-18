using System.Collections.Generic;
using TestNware.Domain.Contracts;
using TestNware.Domain.Queries.Models;

namespace TestNware.Domain.Queries
{
    public class GetCategoriesForDropdownList : IQuery<IEnumerable<CategoryItem>>
    {
    }
}
