using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestNware.Domain.Models;

namespace TestNware.Infra.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Id).HasColumnType("uuid")
                //.HasDefaultValueSql("uuid_generate_v4()")
                .IsRequired();

           // builder.Property(p => p.PublicationDate).HasColumnType("datetime");
        }
    }
}
