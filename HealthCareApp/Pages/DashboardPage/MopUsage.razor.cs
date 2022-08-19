using System;
using HealthCareApp.Data;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.DashboardPage
{
	public partial class MopUsage : ComponentBase
	{

        public MopUsage()
		{
		}

        protected async override Task OnInitializedAsync()
        {
            await Task.CompletedTask;
        }
    }
}
