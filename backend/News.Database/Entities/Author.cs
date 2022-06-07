using News.Database.Common;

namespace News.Database.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
