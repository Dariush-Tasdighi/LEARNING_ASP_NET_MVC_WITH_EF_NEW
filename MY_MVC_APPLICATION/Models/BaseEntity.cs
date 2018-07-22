namespace Models
{
	public abstract class BaseEntity : object
	{
		public BaseEntity() : base()
		{
			// Note: Wrong Usage!
			//Id = new System.Guid();

			Id = System.Guid.NewGuid();
		}

		// **********
		public System.Guid Id { get; set; }
		// **********
	}
}
