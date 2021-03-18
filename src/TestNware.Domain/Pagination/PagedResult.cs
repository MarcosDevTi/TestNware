using System.Collections.Generic;

namespace TestNware.Domain.Pagination
{
    public class PagedResult<T>
    {
        public PagedResult(IEnumerable<T> items, int totalNumberOfItems, Paging<T> paging)
        {
            Items = items;
            TotalNumberOfItems = totalNumberOfItems;
            Paging = paging;
        }

        public IEnumerable<T> Items { get; set; }
        public Paging<T> Paging { get; set; }
        public int TotalNumberOfItems { get; set; }

    }
}
