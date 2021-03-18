using System;
using TestNware.Domain.Contracts;
using TestNware.Domain.Models;

namespace TestNware.Domain.Queries
{
    public class GetPost : IQuery<Post>
    {
        public GetPost(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
