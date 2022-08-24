using DateTimeLibrary;
using HealthCareApp.Components.Dropdown;
using HealthCareApp.Pages.TaskPage;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HealthCareApp.Components.Chart.MopUsage
{
    public partial class ChartMopUsage : ComponentBase
    {
        private DropdownDateRangeOption _dropdownDateRangeOption { get; set; }

        private List<string> _chartBackgroundColors { get; set; }
        private List<string> _chartBorderColors { get; set; }
        private List<string> _chartLabels { get; set; }
        private IDateTimeRange _dateTimeRange { get; set; }
        private string _dateRangeDescription { get; set; }

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
            _dropdownDateRangeOption = new();
            _dateTimeRange = new DateTimeRange
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };
            _dateRangeDescription = string.Empty;
        }

        protected override async Task OnInitializedAsync()
        {
            await RefreshDropdownDateRange();
            await Task.CompletedTask;
        }

        private async Task RefreshDropdownDateRange()
        {
            _dateTimeRange = _dropdownDateRangeOption.DateTimeRange;
            _dateRangeDescription = await _dropdownDateRangeOption.UpdateDateRangeDescription();

            await Task.CompletedTask;
        }
    }
}
