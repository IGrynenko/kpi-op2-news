using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.Database.Entities;

namespace News.Database.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable($"{nameof(Article)}s").
                HasKey(t => t.Id);

            builder.HasOne(a => a.Author)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.AuthorId);

            builder.HasOne(a => a.Category)
                .WithMany(a => a.Articles)
                .HasForeignKey(a => a.CategoryId);

            builder.HasMany(a => a.Tags)
                .WithMany(t => t.Articles)
                .UsingEntity(e => e.ToTable("TagArticles"));

            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(t => t.Text)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
        }
    }
}
