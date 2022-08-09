using System;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.DashboardPage
{
	public partial class Dashboard : ComponentBase
	{
        private AppURL _appURL { get; }

        public Dashboard()
		{
			_appURL = new();
		}
	}
}
