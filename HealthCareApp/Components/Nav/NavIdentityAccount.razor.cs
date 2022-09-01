using System;
using Microsoft.AspNetCore.Components;
using MyApp.Shared;

namespace MyApp.Components.Nav
{
	public partial class NavIdentityAccount : ComponentBase
	{
        private AppURL _appURL { get; }

        public NavIdentityAccount()
		{
            _appURL = new();
        }
	}
}
