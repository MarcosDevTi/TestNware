using System;
using System.ComponentModel.DataAnnotations;
using TestNware.Domain.Contracts;

namespace TestNware.Domain.Commands
{
    public class EditCategory : ICommand
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
