using System;

namespace TestNware.Domain.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Content { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
