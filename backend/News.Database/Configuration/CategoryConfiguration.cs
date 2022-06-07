using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Database.Entities;

namespace News.Database.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").
                HasKey(c => c.Id);

            builder.HasMany(c => c.Articles)
                .WithOne(c => c.Category);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasMaxLength(80)
                .IsRequired();
        }
    }
}
