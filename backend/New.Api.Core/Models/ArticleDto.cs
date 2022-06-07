namespace New.Api.Core.Models
{
    public class ArticleDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

        public AuthorDto Author { get; set; }

        public CategoryDto Category { get; set; }

        public ICollection<TagDto> Tags { get; set; }
    }
}
