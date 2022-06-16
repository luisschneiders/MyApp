using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HealthCareApp.Pages.TrackingInventoryPage
{
	public partial class TrackingInventoryMopMain : ComponentBase
	{
		private bool _isInputFocus { get; set; }

        private TrackingInventoryMopModalStart _trackingInventoryMopModalStart { get; set; }

        public TrackingInventoryMopMain()
		{
            _trackingInventoryMopModalStart = new();
            _isInputFocus = false;
		}

        private async Task OpenModalStartAsync()
        {
            await Task.FromResult(_trackingInventoryMopModalStart.OpenModalStartAsync());
            await Task.CompletedTask;
        }

        private async Task OpenModalDateRangeAsync ()
        {

            await Task.CompletedTask;
        }

        private async Task SetInputFocusInAsync(FocusEventArgs eventArgs)
        {

            if (eventArgs?.Type == "focusin")
            {
                _isInputFocus = true;
            }

            await Task.CompletedTask;
        }

        private async Task SetInputFocusOutAsync(FocusEventArgs eventArgs)
        {

            if (eventArgs?.Type == "focusout")
            {
                _isInputFocus = false;
            }

            await Task.CompletedTask;
        }
    }
}
