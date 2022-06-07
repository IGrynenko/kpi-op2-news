using Microsoft.EntityFrameworkCore;
using News.Database.Entities;
using System.Reflection;

namespace News.Database
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetAssembly(typeof(MainDbContext))
                ?? Assembly.GetExecutingAssembly());

            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Business",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Category
                {
                    Id = 2,
                    Name = "Technology",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Category
                {
                    Id = 3,
                    Name = "Culture",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Category
                {
                    Id = 4,
                    Name = "Health",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Category
                {
                    Id = 5,
                    Name = "General News",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            var tags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Name = "breaking news",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Tag
                {
                    Id = 2,
                    Name = "war",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Tag
                {
                    Id = 3,
                    Name = "lmao",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Tag
                {
                    Id = 4,
                    Name = "sick",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            var authors = new List<Author>
            {
                new Author
                {
                    Id = 1,
                    FirstName = "Rick",
                    LastName = "Sanchez",
                    Login = "Sanchez123",
                    Password = "123123",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Morty",
                    LastName = "Smith",
                    Login = "Master",
                    Password = "123123",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Author
                {
                    Id = 3,
                    FirstName = "Miyamoto",
                    LastName = "Musashi",
                    Login = "Samurai",
                    Password = "123123",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            var articles = new List<Article>
            {
                new Article
                {
                    Id = 1,
                    Title = "Article 1",
                    Text = "Now eldest new tastes plenty mother called misery get. Longer excuse for county nor except met its things. Narrow enough sex moment desire are. Hold who what come that seen read age its. Contained or estimable earnestly so perceived. Imprudence he in sufficient cultivated. Delighted promotion improving acuteness an newspaper offending he. Misery in am secure theirs giving an. Design on longer thrown oppose am.",
                    AuthorId = 1,
                    CategoryId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Article
                {
                    Id = 2,
                    Title = "Article 2",
                    Text = "Carried nothing on am warrant towards. Polite in of in oh needed itself silent course. Assistance travelling so especially do prosperous appearance mr no celebrated. Wanted easily in my called formed suffer. Songs hoped sense as taken ye mirth at. Believe fat how six drawing pursuit minutes far. Same do seen head am part it dear open to. Whatever may scarcely judgment had.",
                    AuthorId = 2,
                    CategoryId = 2,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Article
                {
                    Id = 3,
                    Title = "Article 3",
                    Text = "Society excited by cottage private an it esteems. Fully begin on by wound an. Girl rich in do up or both. At declared in as rejoiced of together. He impression collecting delightful unpleasant by prosperous as on. End too talent she object mrs wanted remove giving.",
                    AuthorId = 3,
                    CategoryId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Article
                {
                    Id = 4,
                    Title = "Article 4",
                    Text = "Is post each that just leaf no. He connection interested so we an sympathize advantages. To said is it shed want do. Occasional middletons everything so to. Have spot part for his quit may. Enable it is square my an regard. Often merit stuff first oh up hills as he. Servants contempt as although addition dashwood is procured. Interest in yourself an do of numerous feelings cheerful confined.",
                    AuthorId = 1,
                    CategoryId = 4,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Article
                {
                    Id = 5,
                    Title = "Article 5",
                    Text = "Is post each that just leaf no. He connection interested so we an sympathize advantages. To said is it shed want do. Occasional middletons everything so to. Have spot part for his quit may. Enable it is square my an regard. Often merit stuff first oh up hills as he. Servants contempt as although addition dashwood is procured. Interest in yourself an do of numerous feelings cheerful confined.",
                    AuthorId = 2,
                    CategoryId = 1,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
            };

            modelBuilder.Entity<Category>()
                .HasData(categories);

            modelBuilder.Entity<Tag>()
                .HasData(tags);

            modelBuilder.Entity<Author>()
                .HasData(authors);

            modelBuilder.Entity<Article>()
                .HasData(articles);
        }
    }
}