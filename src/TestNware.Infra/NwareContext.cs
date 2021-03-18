using Microsoft.EntityFrameworkCore;
using TestNware.Domain.Models;
using TestNware.Infra.Data.Mappings;

namespace TestNware.Infra
{
    public class NwareContext : DbContext
    {
        public NwareContext(DbContextOptions<NwareContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
