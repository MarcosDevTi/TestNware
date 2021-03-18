using System;
using TestNware.Domain.Commands;
using TestNware.Domain.Contracts;

namespace TestNware.Domain.Queries
{
    public class GetPostForEdition : IQuery<EditPost>
    {
        public GetPostForEdition(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
