using System;
using MyApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Security.Cryptography;

namespace MyApp.Components.Chart
{
	public partial class Chart : ComponentBase, IAsyncDisposable
    {
        [Parameter]
		public string Id { get; set; }

        [Parameter]
        public string Title { get; set; }

		[Parameter]
		public ChartType Type { get; set; }

        [Parameter]
		public List<string> Data { get; set; } = default!;

        [Parameter]
        public List<string> BackgroundColor { get; set; } = default!;

        [Parameter]
        public List<string> BorderColor { get; set; } = default!;

        [Parameter]
        public List<string> Labels { get; set; } = default!;

        private IJSObjectReference? _chartModule;
        private IJSObjectReference? _chart;

        private ChartConfig _chartConfig { get; set; }

        public Chart()
		{
            Id = string.Empty;
            Title = string.Empty;
			Type = ChartType.Bar;
            _chartConfig = new();
		}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _chartConfig = new ChartConfig
                {
                    Type = Type.ToString().ToLower(),
                    Data = new ChartConfigData
                    {
                        Labels = Labels,
                        Datasets = new List<ChartConfigDataset>
                        {
                            new ChartConfigDataset
                            {
                                Label = Title,
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

                _chart = await _chartModule.InvokeAsync<IJSObjectReference>("setupChart", Id, _chartConfig);

                Console.WriteLine("LFS - chart: " + _chart);

                StateHasChanged();
            }

            await Task.CompletedTask;
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {

            if (_chartModule is not null)
            {
                await _chartModule.DisposeAsync();
            }

            if (_chart is not null)
            {
                await _chart.DisposeAsync();
            }
        }
    }
}
