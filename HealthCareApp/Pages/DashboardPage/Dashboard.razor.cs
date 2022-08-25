using System;
using DateTimeLibrary;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.DashboardPage
{
	public partial class Dashboard : ComponentBase
	{
        private AppURL _appURL { get; }
		private IDateTimeRange _dateTimeRange { get; set; }

        public Dashboard()
		{
			_appURL = new();
			_dateTimeRange = new DateTimeRange()
			{
				Start = new DateTime(DateTime.Now.Year, 1, 1),
				End = new DateTime(DateTime.Now.Year, 12, 31)
			};
		}
	}
}
