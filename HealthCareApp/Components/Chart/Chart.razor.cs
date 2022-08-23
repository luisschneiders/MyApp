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
        public string LabelTitle { get; set; }

		[Parameter]
		public ChartType ChartType { get; set; }


        [Parameter]
		public string[] Data { get; set; } = default!;

        [Parameter]
        public string[] BackgroundColor { get; set; } = default!;

        [Parameter]
        public string[] BorderColor { get; set; } = default!;

        [Parameter]
        public string[] Labels { get; set; } = default!;

        public Chart()
		{
            LabelTitle = string.Empty;
            ChartId = string.Empty;
			ChartType = ChartType.Bar;
		}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
			    var config = new
			    {
				    type = ChartType.ToString().ToLower(),
                    data = new
                    {
                        labels = Labels,
                        datasets = new[]
                        {
                            new {
                                label = LabelTitle,
                                data = Data,
                                backgroundColor = BackgroundColor,
                                borderColor = BorderColor,
                                borderWidth = 1
                            }
                        },
                    },
                    options = new {},
                };

                await JS.InvokeVoidAsync("setup", ChartId, config);
            }
            await Task.CompletedTask;
        }
    }
}
