namespace Models
{
	public class DatabaseContext : System.Data.Entity.DbContext
	{
		static DatabaseContext()
		{
			// فقط به درد برنامه‌نويسان، آن هم در زمان پياده‌سازی می‌خورد
			//System.Data.Entity.Database.SetInitializer
			//	(new System.Data.Entity.DropCreateDatabaseAlways<DatabaseContext>());

			// فقط به درد برنامه‌نويسان، آن هم در زمان پياده‌سازی می‌خورد
			System.Data.Entity.Database.SetInitializer
				(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>());

			// به درد مشتری می‌خورد
			//System.Data.Entity.Database.SetInitializer
			//	(new System.Data.Entity.CreateDatabaseIfNotExists<DatabaseContext>());
		}

		public DatabaseContext() : base()
		{
		}

		public System.Data.Entity.DbSet<Role> Roles { get; set; }

		public System.Data.Entity.DbSet<User> Users { get; set; }
	}
}
