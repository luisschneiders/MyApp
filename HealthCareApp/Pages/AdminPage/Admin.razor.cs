using System;
using MyApp.Shared;
using Microsoft.AspNetCore.Components;

namespace MyApp.Pages.AdminPage
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
