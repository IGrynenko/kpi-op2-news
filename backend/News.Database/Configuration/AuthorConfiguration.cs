using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Database.Entities;

namespace News.Database.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable($"{nameof(Author)}s").
                HasKey(a => a.Id);

            builder.HasMany(a => a.Articles)
                .WithOne(art => art.Author);

            builder.Property(a => a.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Login)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Password)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
