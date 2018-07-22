namespace Infrastructure
{
	public class BaseController : System.Web.Mvc.Controller
	{
		public BaseController() : base()
		{
			// Solution (5)
			//MyDatabaseContext = new Models.DatabaseContext();
			// /Solution (5)
		}

		// Solution (1)
		//private Models.DatabaseContext myDatabaseContext;
		// /Solution (1)

		// Solution (2)
		//public Models.DatabaseContext MyDatabaseContext;
		// /Solution (2)

		// Solution (3)
		//protected Models.DatabaseContext MyDatabaseContext;
		// /Solution (3)

		// Solution (4)
		//protected Models.DatabaseContext MyDatabaseContext = new Models.DatabaseContext();
		// /Solution (4)

		// Solution (5)
		//protected Models.DatabaseContext MyDatabaseContext;
		// /Solution (5)

		// Solution (6)
		private Models.DatabaseContext myDatabaseContext;

		/// <summary>
		/// Lazy Loading = Lazy Initialization
		/// </summary>
		protected Models.DatabaseContext MyDatabaseContext
		{
			get
			{
				if (myDatabaseContext == null)
				{
					myDatabaseContext =
						new Models.DatabaseContext();
				}

				return (myDatabaseContext);
			}
		}
		// /Solution (6)

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if(myDatabaseContext != null)
				{
					myDatabaseContext.Dispose();
					myDatabaseContext = null;
				}
			}

			base.Dispose(disposing);
		}
	}
}
