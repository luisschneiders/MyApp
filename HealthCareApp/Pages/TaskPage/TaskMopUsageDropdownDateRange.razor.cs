using System;
using DateTimeLibrary;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.TaskPage
{
	public partial class TaskMopUsageDropdownDateRange : ComponentBase
	{

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        public IDateTimeRange _dateTimeRange { get; set; }
        private bool _isValidDateRange { get; set; }

        public TaskMopUsageDropdownDateRange()
		{
            _dateTimeRange = new DateTimeRange
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };
            _isValidDateRange = true;
        }

        private async Task ChangeDateAsync()
        {
            _dateTimeRange.CheckDate();
            if (!_dateTimeRange.CheckDate())
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
            _dateTimeRange = new DateTimeRange
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };
        }
    }
}
