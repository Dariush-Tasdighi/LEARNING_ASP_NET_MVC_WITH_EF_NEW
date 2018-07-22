using System.Linq;

namespace Infrastructure
{
	public abstract class XBaseController<T> : BaseController where T : Models.BaseEntity, new()
	{
		public XBaseController() : base()
		{
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Index()
		{
			var items =
				MyDatabaseContext.Set<T>()
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
				MyDatabaseContext.Set<T>()
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return (HttpNotFound());
			}

			return (View(model: foundedItem));
		}

		protected virtual T GetDefaultItem()
		{
			T defaultItem = new T();

			return (defaultItem);
		}

		protected abstract void SetDropDownLists(T value);

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ViewResult Create()
		{
			T defaultItem = GetDefaultItem();

			SetDropDownLists(null);

			return (View(model: defaultItem));
		}

		public virtual void CheckBusinessValidationForCreating(T model)
		{
		}

		[System.Web.Mvc.HttpPost]
		[System.Web.Mvc.ValidateAntiForgeryToken]
		public virtual System.Web.Mvc.ActionResult Create(T inputViewModel)
		{
			CheckBusinessValidationForCreating(inputViewModel);

			if (ModelState.IsValid)
			{
				MyDatabaseContext.Set<T>().Add(inputViewModel);

				MyDatabaseContext.SaveChanges();

				return (RedirectToAction("Index"));
			}

			SetDropDownLists(inputViewModel);

			return (View(model: inputViewModel));
		}

		[System.Web.Mvc.HttpGet]
		public virtual System.Web.Mvc.ActionResult Delete(System.Guid? id)
		{
			if (id.HasValue == false)
			{
				return (new System.Web.Mvc.HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest));
			}

			var foundedItem =
				MyDatabaseContext.Set<T>()
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
				MyDatabaseContext.Set<T>()
				.Where(current => current.Id == id.Value)
				.FirstOrDefault();

			if (foundedItem == null)
			{
				return (HttpNotFound());
			}

			MyDatabaseContext.Set<T>().Remove(foundedItem);

			MyDatabaseContext.SaveChanges();

			return (RedirectToAction("Index"));
		}
	}
}
