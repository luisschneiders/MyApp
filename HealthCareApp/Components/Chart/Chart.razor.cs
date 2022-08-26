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
		public List<string> Data { get; set; } = default!;

        [Parameter]
        public List<string> BackgroundColor { get; set; } = default!;

        [Parameter]
        public List<string> BorderColor { get; set; } = default!;

        [Parameter]
        public List<string> Labels { get; set; } = default!;

        private ChartConfig _config { get; set; }

        public Chart()
		{
            LabelTitle = string.Empty;
            ChartId = string.Empty;
			ChartType = ChartType.Bar;
            _config = new();
		}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

                _config = new ChartConfig
                {
                    Type = ChartType.Bar.ToString().ToLower(),
                    Data = new ChartConfigData
                    {
                        Labels = Labels,
                        Datasets = new List<ChartConfigDataset>
                        {
                            new ChartConfigDataset
                            {
                                Label = LabelTitle,
                                Data = Data,
                                BackgroundColor = BackgroundColor,
                                BorderColor = BorderColor,
                                BorderWidth = 1
                            }
                        }
                    },
                    Options = new {}
                };

                await JS.InvokeVoidAsync("setup", ChartId, _config);
            }
            await Task.CompletedTask;
        }
    }
}
