namespace New.Api.Core.Models
{
    public class ArticleModel
    {
        public string Title { get; set; }

        public string Text { get; set; }

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

        public int[] Tags { get; set; }
    }
}
