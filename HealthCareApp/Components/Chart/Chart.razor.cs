using System;
using MyApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MyApp.Components.Chart
{
	public partial class Chart : ComponentBase, IAsyncDisposable
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

        private IJSObjectReference? _chartModule;

        private ChartConfig _chartConfig { get; set; }

        public Chart()
		{
            LabelTitle = string.Empty;
            ChartId = string.Empty;
			ChartType = ChartType.Bar;

            _chartConfig = new();
		}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

                _chartConfig = new ChartConfig
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

                _chartModule = await JS.InvokeAsync<IJSObjectReference>("import", "./Components/Chart/Chart.razor.js");

                await _chartModule.InvokeVoidAsync("setupChart", ChartId, _chartConfig);
            }

            await Task.CompletedTask;
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {

            if (_chartModule is not null)
            {
                await _chartModule.DisposeAsync();
            }
        }
    }
}
