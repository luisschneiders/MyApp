using System;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HealthCareApp.Components.Chart
{
	public partial class Chart : ComponentBase
	{
		[Parameter]
		public string ChartId { get; set; }

		[Parameter]
		public ChartType ChartType { get; set; }

		[Parameter]
		public string[] Data { get; set; } = default!;

        [Parameter]
        public string[] BackgroundColor { get; set; } = default!;

        [Parameter]
        public string[] Labels { get; set; } = default!;

        public Chart()
		{
			ChartId = string.Empty;
			ChartType = ChartType.Bar;
		}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
			var config = new
			{
				Type = ChartType.ToString().ToLower(),
                Options = new
                {
                    Responsive = true,
                    Scales = new
                    {
                        YAxes = new[]
                    {
                        new { Ticks = new {
                            BeginAtZero=true
                        } }
                    }
                    }
                },
                Data = new
                {
                    Datasets = new[]
                {
                    new { Data = Data, BackgroundColor = BackgroundColor}
                },
                    Labels = Labels
                }
            };

            await JS.InvokeVoidAsync("setup", ChartId, config);
            await Task.CompletedTask;
        }
    }
}
