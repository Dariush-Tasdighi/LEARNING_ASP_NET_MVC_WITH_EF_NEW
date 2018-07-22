namespace MY_MVC_APPLICATION
{
	public static class FilterConfig
	{
		static FilterConfig()
		{
		}

		public static void RegisterGlobalFilters
			(System.Web.Mvc.GlobalFilterCollection filters)
		{
			filters.Add(new System.Web.Mvc.HandleErrorAttribute());
		}
	}
}
