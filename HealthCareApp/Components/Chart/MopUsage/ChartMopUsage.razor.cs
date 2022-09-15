using DateTimeLibrary;
using MyApp.Components.Dropdown;
using MyApp.Components.Modal;
using MyApp.Data;
using MyApp.Pages.TaskPage;
using MyApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TrackingInventoryLibrary.Models;
using System;

namespace MyApp.Components.Chart.MopUsage
{
    public partial class ChartMopUsage : ComponentBase, IAsyncDisposable
    {
        [Inject]
        private TrackingInventoryMopService _trackingInventoryService { get; set; } = default!;

        [Parameter]
        public IDateTimeRange DateTimeRange { get; set; }

        private List<string> _chartBackgroundColors { get; set; }
        private List<string> _chartBorderColors { get; set; }
        private List<string> _chartLabels { get; set; }
        private List<TrackingInventorySumMopDto> _trackingInventorySumMopDtoList { get; set; }
        private TrackingInventorySumMopDto _trackingInventorySumTotalMop { get; set; }
        private List<string> _chartData { get; set; }

        private IJSObjectReference? _chartModule;
        private IJSObjectReference? _chartObjectReference;

        public ChartMopUsage()
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

            _trackingInventorySumTotalMop = new();
            _chartData = new();

            DateTimeRange = new DateTimeRange
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };

            _trackingInventorySumMopDtoList = new();

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _chartModule = await JS.InvokeAsync<IJSObjectReference>("import", "./Components/Chart/Chart.razor.js");
            }
            await Task.CompletedTask;
        }

        protected override async Task OnInitializedAsync()
        {
            await SetChartData();
            await Task.CompletedTask;
        }

        private async Task RefreshChartFromDropdownDateRange()
        {
            _chartData = new();

            await SetChartData();
            await _chartModule!.InvokeVoidAsync("updateChartData", _chartObjectReference, _chartData);
            await Task.CompletedTask;
        }

        private async Task SetChartObjectReference(IJSObjectReference chartObjectReference)
        {
            _chartObjectReference = chartObjectReference;

            await Task.FromResult(_chartModule!.InvokeVoidAsync("updateChartData", _chartObjectReference, _chartData));
            await Task.CompletedTask;
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {

            if (_chartModule is not null)
            {
                await _chartModule.DisposeAsync();
            }

            if (_chartObjectReference is not null)
            {
                await _chartObjectReference.DisposeAsync();
            }
        }

        private async Task SetChartData()
        {
            _trackingInventorySumMopDtoList = await _trackingInventoryService.GetTrackingInventoryMopSumByDateAsync(DateTimeRange);
            _trackingInventorySumTotalMop = new()
            {
                MopQuantity = _trackingInventorySumMopDtoList.Sum(s => s.MopQuantity),
                CleanMopQuantity = _trackingInventorySumMopDtoList.Sum(s => s.CleanMopQuantity),
                DirtyMopQuantity = _trackingInventorySumMopDtoList.Sum(s => s.DirtyMopQuantity),
            };

            _chartData.Add((_trackingInventorySumTotalMop.MopQuantity - (_trackingInventorySumTotalMop.CleanMopQuantity + _trackingInventorySumTotalMop.DirtyMopQuantity)).ToString());
            _chartData.Add(_trackingInventorySumTotalMop.DirtyMopQuantity.ToString());
            _chartData.Add(_trackingInventorySumTotalMop.CleanMopQuantity.ToString());
        }
    }
}
