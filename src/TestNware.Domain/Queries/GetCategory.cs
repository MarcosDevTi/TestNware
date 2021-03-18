using System;
using System.Collections.Generic;
using System.Text;
using TestNware.Domain.Contracts;
using TestNware.Domain.Models;

namespace TestNware.Domain.Queries
{
    public class GetCategory: IQuery<Category>
    {
        public Guid Id { get; set; }

        public GetCategory(Guid id)
        {
            Id = id;
        }
    }
}
