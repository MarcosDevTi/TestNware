using System;
using System.ComponentModel.DataAnnotations;

namespace TestNware.Domain.Commands
{
    public class EditPost
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public Guid CategoryId { get; set; }
        public string Content { get; set; }
    }
}
