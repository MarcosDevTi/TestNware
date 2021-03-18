using System.ComponentModel.DataAnnotations;
using TestNware.Domain.Contracts;

namespace TestNware.Domain.Commands
{
    public class CreateCategory : ICommand
    {
        [Required]
        public string Title { get; set; }
    }
}
