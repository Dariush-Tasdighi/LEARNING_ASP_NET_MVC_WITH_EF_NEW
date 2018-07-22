namespace Models
{
	public class Country : BaseEntity
	{
		public Country() : base()
		{
		}

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
