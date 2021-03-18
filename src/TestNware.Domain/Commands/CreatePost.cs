using System;
using TestNware.Domain.Contracts;

namespace TestNware.Domain.Commands
{
    public class CreatePost : ICommand
    {
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid CategoryId { get; set; }
        public string Content { get; set; }
    }
}
