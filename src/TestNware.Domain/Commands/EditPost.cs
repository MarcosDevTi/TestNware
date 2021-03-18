using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TestNware.Domain.Contracts;
using TestNware.Domain.Queries.Models;

namespace TestNware.Domain.Commands
{
    public class EditPost : ICommand
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        [DisplayName("Pub Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PublicationDate { get; set; }
        [Required]
        [DisplayName("Category")]
        public Guid CategoryId { get; set; }
        [Required]
        public string Content { get; set; }
        public IEnumerable<CategoryItem> Categories { get; set; }
    }
}
