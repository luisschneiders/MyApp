using DateTimeLibrary;
using HealthCareApp.Components.Modal;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.TaskPage
{
	public partial class TaskMopUsageModalDate : ComponentBase
	{
        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal _modal { get; set; }

        private Guid _modalTarget { get; set; }

        public IDateTimeRange DateTimeRange { get; set; }
        private bool _isValidDateRange { get; set; }

        public TaskMopUsageModalDate()
		{
            _modal = new();
            DateTimeRange = new DateTimeRange
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };
            _isValidDateRange = true;
        }

        public async Task OpenModalAsync()
        {

            _modalTarget = Guid.NewGuid();

            await Task.FromResult(_modal.Open(_modalTarget));
            await Task.CompletedTask;
        }

        private async Task CloseModalAsync()
        {

            ResetDateRange();

            await Task.FromResult(_modal.Close(_modalTarget));
            await Task.CompletedTask;
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
                await CloseModalAsync();
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
