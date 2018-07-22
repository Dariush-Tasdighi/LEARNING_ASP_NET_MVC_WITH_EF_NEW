using System.Linq;

namespace MY_MVC_APPLICATION.Controllers
{
	public partial class RolesController : Infrastructure.BaseController
	{
		public RolesController() : base()
		{
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Index()
		{
			var items =
				MyDatabaseContext.Roles
				.OrderBy(current => current.Name)
				.ToList()
				;

			return (View(model: items));
		}

		//[System.Web.Mvc.HttpGet]
		//public virtual System.Web.Mvc.ActionResult Details(System.Guid id)
		//{
		//}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Details(System.Guid? id)
		{
			//if (id == null)
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			//Models.Role foundedItem =
			//	MyDatabaseContext.Roles.Find(id);

			var foundedItem =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return (HttpNotFound());
			}

			return (View(model: foundedItem));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Create()
		{
			//return (View());

			// **************************************************
			Models.Role defaultItem = new Models.Role();

			defaultItem.IsActive = true;
			// **************************************************

			return (View(model: defaultItem));
		}

		//[System.Web.Mvc.HttpPost]
		//[System.Web.Mvc.ValidateAntiForgeryToken]
		//public virtual System.Web.Mvc.ActionResult Create(System.Web.Mvc.FormCollection formCollection)
		//{
		//	string ageString = formCollection["Age"];
		//	int ageInt = 0;
		//	if(string.IsNullOrWhiteSpace(ageString) == false)
		//	{
		//		try
		//		{
		//			ageInt =
		//				System.Convert.ToInt32(ageString);
		//		}
		//		catch
		//		{
		//		}
		//	}

		//	Models.User user = new Models.User();

		//	user.Age = ageInt;

		//	return (null);
		//}

		//[System.Web.Mvc.HttpPost]
		//[System.Web.Mvc.ValidateAntiForgeryToken]
		//public virtual System.Web.Mvc.ActionResult Create(string name, bool isActive)
		//{
		//	Models.Role role = new Models.Role();

		//	role.Name = name;
		//	role.IsActive = isActive;

		//	return (null);
		//}

		//[System.Web.Mvc.HttpPost]
		//[System.Web.Mvc.ValidateAntiForgeryToken]
		//public virtual System.Web.Mvc.ActionResult Create(Models.Role role)
		//{
		//	return (null);
		//}

		//[System.Web.Mvc.HttpPost]
		//[System.Web.Mvc.ValidateAntiForgeryToken]
		//public virtual System.Web.Mvc.ActionResult Create
		//	([System.Web.Mvc.Bind(Include = "IsActive,Name")] Models.Role role)
		//{
		//	return (null);
		//}

		//[System.Web.Mvc.HttpPost]
		//[System.Web.Mvc.ValidateAntiForgeryToken]
		//public virtual System.Web.Mvc.ActionResult Create
		//	([System.Web.Mvc.Bind(Exclude = "Id")] Models.Role role)
		//{
		//	return (null);
		//}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult
			Create([System.Web.Mvc.Bind(Exclude = "Id")] Models.Role role)
		{
			// **************************************************
			var foundedItem =
				MyDatabaseContext.Roles
				.Where(current => string.Compare(current.Name, role.Name, true) == 0)
				.FirstOrDefault();

			if (foundedItem != null)
			{
				ModelState.AddModelError
					(key: "Name", errorMessage: "Name is exist! Please choose another one...");

				// Note: Wrong Usage! Runtime Error!
				//ModelState.AddModelError
				//	(key: null, errorMessage: "Name is exist! Please choose another one...");

				//ModelState.AddModelError
				//	(key: string.Empty, errorMessage: "Name is exist! Please choose another one...");
			}
			// **************************************************

			if (ModelState.IsValid)
			{
				MyDatabaseContext.Roles.Add(role);

				MyDatabaseContext.SaveChanges();

				return (RedirectToAction(MVC.Roles.Index()));
			}

			// Note: Wrong Usage!
			//return (View());

			return (View(model: role));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Edit(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			var foundedItem =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return (HttpNotFound());
			}

			return (View(model: foundedItem));
		}

		//[System.Web.Mvc.HttpPost]
		//[System.Web.Mvc.ValidateAntiForgeryToken]
		//public virtual System.Web.Mvc.ActionResult Edit
		//	([System.Web.Mvc.Bind(Include = "Id,IsActive,Name")] Models.Role role)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		MyDatabaseContext.Entry(role).State = System.Data.Entity.EntityState.Modified;

		//		MyDatabaseContext.SaveChanges();

		//		return (RedirectToAction(MVC.Roles.Index()));
		//	}

		//	return (View(model: role));
		//}

		//[System.Web.Mvc.HttpPost]
		//[System.Web.Mvc.ValidateAntiForgeryToken]
		//public virtual System.Web.Mvc.ActionResult Edit(Models.Role role)
		//{
		//	// **************************************************
		//	Models.Role originalItem =
		//		MyDatabaseContext.Roles.Find(role.Id);

		//	if (originalItem == null)
		//	{
		//		return (HttpNotFound());
		//	}
		//	// **************************************************

		//	if (ModelState.IsValid)
		//	{
		//		originalItem.Name = role.Name;
		//		originalItem.IsActive = role.IsActive;

		//		MyDatabaseContext.SaveChanges();

		//		return (RedirectToAction(MVC.Roles.Index()));
		//	}

		//	return (View(model: role));
		//}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Edit(Models.Role role)
		{
			// **************************************************
			Models.Role originalItem =
				MyDatabaseContext.Roles.Find(role.Id);

			if (originalItem == null)
			{
				return (HttpNotFound());
			}
			// **************************************************

			// **************************************************
			var foundedItem =
				MyDatabaseContext.Roles
				.Where(current => current.Id != role.Id)
				.Where(current => string.Compare(current.Name, role.Name, true) == 0)
				.FirstOrDefault();

			if (foundedItem != null)
			{
				ModelState.AddModelError
					(key: "Name", errorMessage: "Name is exist! Please choose another one...");
			}
			// **************************************************

			if (ModelState.IsValid)
			{
				originalItem.Name = role.Name;
				originalItem.IsActive = role.IsActive;

				MyDatabaseContext.SaveChanges();

				return (RedirectToAction(MVC.Roles.Index()));
			}

			return (View(model: role));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Delete(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			var foundedItem =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return (HttpNotFound());
			}

			return (View(model: foundedItem));
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		[System.Web.Mvc.ActionName(name: "Delete")]
		public virtual System.Web.Mvc.ActionResult DeleteConfirmed(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			var foundedItem =
				MyDatabaseContext.Roles
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return (HttpNotFound());
			}

			MyDatabaseContext.Roles.Remove(foundedItem);

			MyDatabaseContext.SaveChanges();

			return (RedirectToAction(MVC.Roles.Index()));
		}
	}
}
