using System;
using DateTimeLibrary;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Dropdown
{
	public partial class DropdownDateRangeOption : ComponentBase
	{
        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        public IDateTimeRange DateTimeRange { get; set; }
        private bool _isValidDateRange { get; set; }

        public DropdownDateRangeOption()
		{
            DateTimeRange = new DateTimeRange
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };
            _isValidDateRange = true;
        }

        public async Task<string> UpdateDateRangeDescription()
        {
            string dateRangeDescription = string.Empty;
            if (DateTimeRange.Start.Date == DateTimeRange.End.Date)
            {
                dateRangeDescription = $"{DateTimeRange.Start.Date.ToString("dd/MM/yy")}";
            }
            else
            {
                dateRangeDescription = $"{DateTimeRange.Start.Date.ToString("dd/MM/yy")} - {DateTimeRange.End.Date.ToString("dd/MM/yy")}";
            }

            return await Task.FromResult(dateRangeDescription);
        }

        private async Task ChangeDateAsync()
        {
            DateTimeRange.CheckDate();
            if (!DateTimeRange.CheckDate())
            {
                _isValidDateRange = false;
                ResetDateRange();
            }
            else
            {
                _isValidDateRange = true;
                await OnSubmitSuccess.InvokeAsync();
            }
            await Task.CompletedTask;
        }

        private void ResetDateRange()
        {
            DateTimeRange = new DateTimeRange
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };
        }
    }
}
