using News.Database.Common;

namespace News.Database.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
