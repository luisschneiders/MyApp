using System;
using Microsoft.AspNetCore.Components;
using MyApp.Shared;

namespace MyApp.Areas.Identity.Pages.Account
{
	public partial class Manage : ComponentBase
	{
        private AppURL _appURL { get; }

        public Manage()
		{
            _appURL = new();
        }
	}
}
