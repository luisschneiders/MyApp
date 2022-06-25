using HealthCareApp.Components.Spinner;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HealthCareApp.Pages.TrackingInventoryPage
{
	public partial class TrackingInventoryMopMain : ComponentBase
	{

        [Inject]
        private LabelMopService _labelMopService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; } = default!;

        [Inject]
        private SpinnerService _spinnerService { get; set; }

        private LabelMopDto _labelMopDto { get; set; }

        private string _barcode { get; set; }
        private bool _isInputFocus { get; set; }
        private bool _isDisabled { get; set; }
        private bool _isLoading { get; set; }

        private TrackingInventoryMopModalPickup _trackingInventoryMopModalPickup { get; set; }

        public TrackingInventoryMopMain()
		{
            _spinnerService = new();
            _labelMopDto = new();
            _barcode = string.Empty;
            _trackingInventoryMopModalPickup = new();
            _isInputFocus = false;
		}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await Task.Run(() => _spinnerService.ShowSpinner());
            await Task.CompletedTask;
        }

        private async Task OpenModalPickupAsync()
        {
            _isLoading = true;
            _labelMopDto = await _labelMopService.GetLabelMopByBarcodeAsync(_barcode);

            if (_labelMopDto?.Barcode?.Length > 0)
            {
                await Task.FromResult(_trackingInventoryMopModalPickup.OpenModalPickupAsync(_labelMopDto));
            }
            else
            {
                _toastService.ShowToast($"Barcode not found!", Level.Warning);
            }

            await Task.Delay((int)Delay.DataLoading);

            _isLoading = false;
            await Task.Run(() => _spinnerService.HideSpinner());
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

        protected override async Task OnInitializedAsync()
        {
            _isDisabled = true;
            await Task.CompletedTask;
        }

        private void OnValueChanged(ChangeEventArgs args)
        {
            var valueChanged = args?.Value?.ToString();

            if (string.IsNullOrEmpty(valueChanged))
            {
                _isDisabled = true;
            }
            else
            {
                _isDisabled = false;
            }
        }
    }
}
