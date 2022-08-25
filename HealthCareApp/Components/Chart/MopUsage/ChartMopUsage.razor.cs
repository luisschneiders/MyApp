using DateTimeLibrary;
using HealthCareApp.Components.Dropdown;
using HealthCareApp.Components.Modal;
using HealthCareApp.Pages.TaskPage;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HealthCareApp.Components.Chart.MopUsage
{
    public partial class ChartMopUsage : ComponentBase
    {
        [Parameter]
        public IDateTimeRange DateTimeRange { get; set; }

        private List<string> _chartBackgroundColors { get; set; }
        private List<string> _chartBorderColors { get; set; }
        private List<string> _chartLabels { get; set; }
        private IDateTimeRange _dateTimeRange { get; set; }

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

            _dateTimeRange = new DateTimeRange
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };

            DateTimeRange = _dateTimeRange;

        }

        protected override async Task OnInitializedAsync()
        {
            _dateTimeRange = DateTimeRange;

            await Task.CompletedTask;
        }

        private async Task RefreshChartFromDropdownDateRange()
        {
            await Task.CompletedTask;
        }
    }
}
