using System;
using HealthCareApp.Components.Chart;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.DashboardPage
{
	public partial class MopUsage : ComponentBase
	{

        private List<string> _chartBackgroundColors { get; set; }
        private List<string> _chartBorderColors { get; set; }
        private List<string> _chartLabels { get; set; }

        public MopUsage()
		{
            _chartBackgroundColors = new()
            {
                BackgroundColor.Red,
                BackgroundColor.Yellow,
                BackgroundColor.Green

            };
            _chartBorderColors = new()
            {
                BorderColor.Red,
                BorderColor.Yellow,
                BorderColor.Green
            };
            _chartLabels = new()
            {
                MopStatus.Missing.ToString(),
                MopStatus.Dirty.ToString(),
                MopStatus.Clean.ToString(),
            };
        }

        protected async override Task OnInitializedAsync()
        {
            await Task.CompletedTask;
        }
    }
}
