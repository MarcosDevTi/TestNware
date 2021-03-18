using System.Threading.Tasks;
using TestNware.Domain.Commands;
using TestNware.Domain.Contracts;
using TestNware.Domain.Models;
using TestNware.Infra.Data;

namespace TestNware.Infra.Handlers
{
    public class CategoryCommandHandler :
        ICommandHandler<CreateCategory>

    {
        private readonly NWareContext _context;

        public CategoryCommandHandler(NWareContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCategory command)
        {
            var newCategory = new Category
            {
                Title = command.Title
            };

            await _context.AddAsync(newCategory);
            await _context.SaveChangesAsync();
        }
    }
}
