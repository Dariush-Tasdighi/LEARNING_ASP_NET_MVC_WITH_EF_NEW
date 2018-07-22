using System.Linq;

namespace MY_MVC_APPLICATION.Controllers
{
	public partial class UsersController : Infrastructure.BaseController
	{
		public UsersController() : base()
		{
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Index()
		{
			var items =
				MyDatabaseContext.Users
				.OrderBy(current => current.FullName)
				.ToList()
				;

			return (View(model: items));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Details(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			var foundedItem =
				MyDatabaseContext.Users
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
			// **************************************************
			Models.User defaultItem = new Models.User();

			defaultItem.Age = 20;
			defaultItem.IsActive = true;
			// **************************************************

			// **************************************************
			var roles =
				MyDatabaseContext.Roles
				.Where(current => current.IsActive)
				.ToList()
				;

			ViewBag.RoleId =
				new System.Web.Mvc.SelectList
				(items: roles, dataValueField: "Id", dataTextField: "Name", selectedValue: null);
			// **************************************************

			return (View(model: defaultItem));
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Create
			([System.Web.Mvc.Bind(Exclude = "Id")] Models.User user)
		{
			// **************************************************
			var foundedItem =
				MyDatabaseContext.Users
				.Where(current => string.Compare(current.Username, user.Username, true) == 0)
				.FirstOrDefault();

			if (foundedItem != null)
			{
				ModelState.AddModelError
					(key: "Username", errorMessage: "Username is exist! Please choose another one...");
			}
			// **************************************************

			if (ModelState.IsValid)
			{
				MyDatabaseContext.Users.Add(user);

				MyDatabaseContext.SaveChanges();

				return (RedirectToAction(MVC.Users.Index()));
			}

			// **************************************************
			//return (View());
			// **************************************************

			// **************************************************
			//return (View(model: user));
			// **************************************************

			// **************************************************
			//var roles =
			//	MyDatabaseContext.Roles
			//	.Where(current => current.IsActive)
			//	.ToList()
			//	;

			//ViewBag.RoleId =
			//	new System.Web.Mvc.SelectList
			//	(items: roles, dataValueField: "Id", dataTextField: "Name", selectedValue: null);

			//return (View(model: user));
			// **************************************************

			// **************************************************
			var roles =
				MyDatabaseContext.Roles
				.Where(current => current.IsActive)
				.ToList()
				;

			ViewBag.RoleId =
				new System.Web.Mvc.SelectList
				(items: roles, dataValueField: "Id", dataTextField: "Name", selectedValue: user.RoleId);

			return (View(model: user));
			// **************************************************
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Edit(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			var foundedItem =
				MyDatabaseContext.Users
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return (HttpNotFound());
			}

			// **************************************************
			var roles =
				MyDatabaseContext.Roles
				.Where(current => current.IsActive)
				.ToList()
				;

			ViewBag.RoleId =
				new System.Web.Mvc.SelectList
				(items: roles, dataValueField: "Id", dataTextField: "Name", selectedValue: foundedItem.RoleId);
			// **************************************************

			return (View(model: foundedItem));
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Edit(Models.User user)
		{
			// **************************************************
			Models.User originalItem =
				MyDatabaseContext.Users.Find(user.Id);

			if (originalItem == null)
			{
				return (HttpNotFound());
			}
			// **************************************************

			// **************************************************
			var foundedItem =
				MyDatabaseContext.Users
				.Where(current => current.Id != user.Id)
				.Where(current => string.Compare(current.Username, user.Username, true) == 0)
				.FirstOrDefault();

			if (foundedItem != null)
			{
				ModelState.AddModelError
					(key: "Username", errorMessage: "Username is exist! Please choose another one...");
			}
			// **************************************************

			if (ModelState.IsValid)
			{
				originalItem.Age = user.Age;
				originalItem.RoleId = user.RoleId;
				originalItem.FullName = user.FullName;
				originalItem.IsActive = user.IsActive;
				originalItem.Password = user.Password;
				originalItem.Username = user.Username;
				originalItem.Description = user.Description;

				MyDatabaseContext.SaveChanges();

				return (RedirectToAction(MVC.Users.Index()));
			}

			// **************************************************
			var roles =
				MyDatabaseContext.Roles
				.Where(current => current.IsActive)
				.ToList()
				;

			ViewBag.RoleId =
				new System.Web.Mvc.SelectList
				(items: roles, dataValueField: "Id", dataTextField: "Name", selectedValue: user.RoleId);
			// **************************************************

			return (View(model: user));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Delete(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			var foundedItem =
				MyDatabaseContext.Users
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
				MyDatabaseContext.Users
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return (HttpNotFound());
			}

			MyDatabaseContext.Users.Remove(foundedItem);

			MyDatabaseContext.SaveChanges();

			return (RedirectToAction(MVC.Users.Index()));
		}
	}
}
