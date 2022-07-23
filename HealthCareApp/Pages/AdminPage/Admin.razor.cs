using System;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.AdminPage
{
	public partial class Admin : ComponentBase
	{
		private AppURL _appURL { get; }

		public Admin()
		{
			_appURL = new();
		}
	}
}
