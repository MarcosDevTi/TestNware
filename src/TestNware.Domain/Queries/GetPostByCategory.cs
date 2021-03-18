using System;
using System.Collections.Generic;
using TestNware.Domain.Contracts;
using TestNware.Domain.Models;

namespace TestNware.Domain.Queries
{
    public class GetPostByCategory : IQuery<IEnumerable<Post>>
    {

        public Guid CategoryId { get; set; }

        public GetPostByCategory(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
