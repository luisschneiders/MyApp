using DateTimeLibrary;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
//using Microsoft.JSInterop;
using TrackingInventoryLibrary.Models;

namespace HealthCareApp.Pages.TrackingInventoryPage
{
	public partial class TrackingInventoryMopMain : ComponentBase
	{

        [Inject]
        private LabelMopService _labelMopService { get; set; } = default!;

        [Inject]
        private TrackingInventoryMopService _trackingInventoryMopService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; } = default!;

        [Inject]
        private SpinnerService _spinnerService { get; set; }

        private TrackingInventoryMopModalPickup _trackingInventoryMopModalPickup { get; set; }

        //private IJSObjectReference? _module;

        private LabelMopDto _labelMopDto { get; set; }

        private Virtualize<TrackingInventoryMopDto> _virtualizeContainer { get; set; }

        private List<TrackingInventoryMopDto> _trackingInventoryMopDto { get; set; }

        private string _barcode { get; set; }
        private bool _isInputFocus { get; set; }
        private bool _isDisabled { get; set; }
        private bool _isLoading { get; set; }

        public TrackingInventoryMopMain()
		{
            _spinnerService = new();
            _labelMopDto = new();
            _virtualizeContainer = new();
            _trackingInventoryMopDto = new();
            _barcode = string.Empty;
            _trackingInventoryMopModalPickup = new();
            _isInputFocus = false;
		}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await Task.Run(() => _spinnerService.ShowSpinner());

            /*
             * async import js file
             */
            //if (firstRender)
            //{
            //    _module = await JS.InvokeAsync<IJSObjectReference>("import",
            //        "./Pages/TrackingInventoryPage/TrackingInventoryMopMain.razor.js");
            //}

            await Task.CompletedTask;
        }

        /*
         * async dispose module
         */
        //async ValueTask IAsyncDisposable.DisposeAsync()
        //{
        //    if (_module is not null)
        //    {
        //        await _module.DisposeAsync();
        //    }
        //}

        private async Task OpenModalPickupAsync()
        {
            _isLoading = true;
            _labelMopDto = await _labelMopService.GetLabelMopByBarcodeAsync(_barcode);

            if (_labelMopDto?.Barcode?.Length > 0)
            {
                await Task.FromResult(_trackingInventoryMopModalPickup.OpenModalPickupAsync(_labelMopDto));
                _isDisabled = true;
                _barcode = string.Empty;
            }
            else
            {
                _toastService.ShowToast($"Barcode not found!", Level.Danger);
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

        private async Task RefreshVirtualizeContainer()
        {
            await _virtualizeContainer.RefreshDataAsync();
        }

        private async ValueTask<ItemsProviderResult<TrackingInventoryMopDto>> LoadTrackingInventoryMops(ItemsProviderRequest request)
        {
            IDateTimeRange dateTimeRange = new DateTimeRange();
            dateTimeRange.Start = DateTime.Now;
            dateTimeRange.End = DateTime.Now;

            _trackingInventoryMopDto = await _trackingInventoryMopService.GetTrackingInventoryMopByDateAsync(dateTimeRange);

            await Task.Run(() => _spinnerService.HideSpinner());

            await InvokeAsync(() => StateHasChanged());

            return new ItemsProviderResult<TrackingInventoryMopDto>(
                _trackingInventoryMopDto.Skip(request.StartIndex).Take(request.Count), _trackingInventoryMopDto.Count
            );
        }
    }
}
