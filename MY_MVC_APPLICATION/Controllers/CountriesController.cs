namespace MY_MVC_APPLICATION.Controllers
{
	public partial class CountriesController : Infrastructure.XBaseController<Models.Country>
	{
		public CountriesController() : base()
		{
		}

		protected override void SetDropDownLists(Models.Country value)
		{
		}
	}
}
