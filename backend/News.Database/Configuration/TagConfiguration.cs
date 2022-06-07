using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Database.Entities;

namespace News.Database.Configuration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable($"{nameof(Tag)}s").
                HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .HasMaxLength(80)
                .IsRequired();
        }
    }
}
