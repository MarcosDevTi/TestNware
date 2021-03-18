using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestNware.Domain.Models;

namespace TestNware.Infra.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Id).HasColumnType("uuid").IsRequired();

            builder.Property(p => p.Title).IsRequired();

            builder.Property(p => p.PublicationDate).IsRequired();

            builder.Property(p => p.CategoryId).IsRequired();

            builder.Property(p => p.Content).IsRequired();

            builder.HasIndex(p => p.Title).IsUnique();
        }
    }
}
