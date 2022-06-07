namespace News.Database.Common
{
	public abstract class BaseEntity : AuditableEntity
	{
		public int Id { get; set; }
	}
}
