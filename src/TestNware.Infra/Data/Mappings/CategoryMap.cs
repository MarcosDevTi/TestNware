using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestNware.Domain.Models;

namespace TestNware.Infra.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Id).HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Title).IsRequired();

            builder.HasIndex(p => p.Title).IsUnique();
        }
    }
}
