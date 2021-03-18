using System;
using System.Linq;
using TestNware.Domain.Commands;
using TestNware.Domain.Contracts;
using TestNware.Domain.DomainNotification;
using TestNware.Domain.Models;
using TestNware.Infra.Data;

namespace TestNware.Infra.Handlers
{
    public class PostCommandHandler :
        ICommandHandler<CreatePost>,
        ICommandHandler<EditPost>
    {
        private readonly NWareContext _context;
        private readonly INotificationContext _notificationContext;

        public PostCommandHandler(NWareContext context, INotificationContext notificationContext)
        {
            _context = context;
            _notificationContext = notificationContext;
        }

        public void Handle(CreatePost command)
        {
            if (_context.Posts.Any(c => c.Title == command.Title))
            {
                _notificationContext.AddNotification(nameof(CreatePost.Title), $"The {nameof(CreatePost.Title)} '{command.Title}' already exists");
                return;
            }

            var category = _context.Categories.Find(command.CategoryId);
            var newPost = new Post
            {
                Title = command.Title,
                Content = command.Content,
                PublicationDate = command.PublicationDate.Value,
                Category = category,
                CreatedDate = DateTime.Now
            };

            _context.Add(newPost);
            _context.SaveChanges();
        }

        public void Handle(EditPost command)
        {
            if (_context.Categories.Any(c => c.Title == command.Title && c.Id != command.Id))
            {

                _notificationContext.AddNotification(nameof(EditPost.Title), $"The {nameof(EditPost.Title)} '{command.Title}' already exists");
                return;
            }

            var category = _context.Categories.Find(command.CategoryId);
            var updateCategory = new Post
            {
                Id = command.Id,
                Title = command.Title,
                Content = command.Content,
                PublicationDate = command.PublicationDate,
                Category = category
            };

            _context.Update(updateCategory);
            _context.SaveChanges();
        }
    }
}
