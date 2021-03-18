using System;
using TestNware.Domain.Commands;
using TestNware.Domain.Contracts;
using TestNware.Domain.Queries.Models;

namespace TestNware.Domain.Queries
{
    public class GetCategoryForEdition : IQuery<EditCategory>
    {
        public GetCategoryForEdition(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}