using News.Database.Common;

namespace News.Database.Entities
{
    public class Article : BaseEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
