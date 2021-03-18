using System.Threading.Tasks;
using TestNware.Domain.Commands;
using TestNware.Domain.Contracts;
using TestNware.Domain.Models;
using TestNware.Infra.Data;

namespace TestNware.Infra.Handlers
{
    public class PostCommandHandler :
        ICommandHandler<CreatePost>
    {
        private readonly NWareContext _context;

        public PostCommandHandler(NWareContext context)
        {
            _context = context;
        }

        public async Task Handle(CreatePost command)
        {
            var category = await _context.Categories.FindAsync(command.CategoryId);
            var newPost = new Post
            {
                Title = command.Title,
                Content = command.Content,
                PublicationDate = command.PublicationDate,
                Category = category,
            };

            await _context.AddAsync(newPost);
            await _context.SaveChangesAsync();
        }
    }
}
