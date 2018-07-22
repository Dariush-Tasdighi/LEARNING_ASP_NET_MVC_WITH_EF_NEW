namespace Models
{
	public class Role : BaseEntity
	{
		public Role() : base()
		{
			IsActive = true;
		}

		// **********
		[System.ComponentModel.DataAnnotations.Display
			(Name = "Active")]
		public bool IsActive { get; set; }
		// **********

		// **********
		[System.ComponentModel.DataAnnotations.Required
			(AllowEmptyStrings = false)]

		[System.ComponentModel.DataAnnotations.StringLength
			(maximumLength: 50)]

		[System.ComponentModel.DataAnnotations.Schema.Index
			(IsUnique = true)]
		public string Name { get; set; }
		// **********

		// **********
		public virtual System.Collections.Generic.IList<User> Users { get; set; }
		// **********
	}
}
