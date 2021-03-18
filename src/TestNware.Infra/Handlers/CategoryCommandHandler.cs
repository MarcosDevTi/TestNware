using System.Linq;
using TestNware.Domain.Commands;
using TestNware.Domain.Contracts;
using TestNware.Domain.DomainNotification;
using TestNware.Domain.Models;
using TestNware.Infra.Data;

namespace TestNware.Infra.Handlers
{
    public class CategoryCommandHandler :
        ICommandHandler<CreateCategory>,
        ICommandHandler<EditCategory>
    {
        private readonly NWareContext _context;
        private readonly INotificationContext _notificationContext;
        public CategoryCommandHandler(NWareContext context, INotificationContext notificationContext)
        {
            _context = context;
            _notificationContext = notificationContext;
        }

        public void Handle(CreateCategory command)
        {
            if (_context.Categories.Any(c => c.Title == command.Title))
            {

                _notificationContext.AddNotification(nameof(CreateCategory.Title), $"The {nameof(CreateCategory.Title)} '{command.Title}' already exists");
                return;
            }
            var newCategory = new Category
            {
                Title = command.Title
            };

            _context.Add(newCategory);
            _context.SaveChanges();
        }

        public void Handle(EditCategory command)
        {
            if (_context.Categories.Any(c => c.Title == command.Title && c.Id != command.Id))
            {

                _notificationContext.AddNotification(nameof(EditCategory.Title), $"The {nameof(EditCategory.Title)} '{command.Title}' already exists");
                return;
            }

            var updateCategory = new Category
            {
                Id = command.Id,
                Title = command.Title
            };

            _context.Update(updateCategory);
            _context.SaveChanges();
        }
    }
}
