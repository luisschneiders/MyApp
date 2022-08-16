using System;
using DateTimeLibrary;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Pages.TrackingInventoryPage;
using HealthCareApp.Settings.Enum;
using HealthCareApp.Shared;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using TrackingInventoryLibrary.Models;

namespace HealthCareApp.Pages.TaskPage
{
    public partial class TaskMopUsage : ComponentBase
    {

        [Inject]
        private LabelMopService _labelMopService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; } = default!;

        [Inject]
        private TrackingInventoryMopService _trackingInventoryMopService { get; set; } = default!;

        private TaskMopUsageModal _taskMopUsageModal { get; set; }
        private Virtualize<TrackingInventoryMopDto> _virtualizeContainer { get; set; }
        private AppURL _appURL { get; }
        private LabelMopDto _labelMopDto { get; set; }
        private List<TrackingInventoryMopDto> _trackingInventoryMopDto { get; set; }
        private EntryType[] _entryTypes { get; set; } = default!;
        private ShiftType[] _shiftTypes { get; set; } = default!;
        private string _barcode { get; set; }
        private bool _isInputFocus { get; set; }
        private bool _isDisabled { get; set; }
        private bool _isLoading { get; set; }
        private bool _hasSearchResults { get; set; }

        public TaskMopUsage()
        {
            _taskMopUsageModal = new();
            _virtualizeContainer = new();
            _appURL = new();
            _labelMopDto = new();
            _trackingInventoryMopDto = new();
            _entryTypes = (EntryType[])Enum.GetValues(typeof(EntryType));
            _shiftTypes = (ShiftType[])Enum.GetValues(typeof(ShiftType));
            _barcode = string.Empty;
            _isInputFocus = false;
            _isDisabled = false;
            _isLoading = false;
            _hasSearchResults = false;
        }

        private async Task RefreshVirtualizeContainer()
        {
            await _virtualizeContainer.RefreshDataAsync();
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

        private async Task OpenModalAsync()
        {
            _isLoading = true;
            _labelMopDto = await _labelMopService.GetLabelMopByBarcodeAsync(_barcode);

            if (_labelMopDto?.Barcode?.Length > 0)
            {
                await Task.FromResult(_taskMopUsageModal.OpenModalAsync(_labelMopDto));
                _isDisabled = true;
                _barcode = string.Empty;
            }
            else
            {
                _toastService.ShowToast($"Barcode not found!", Level.Danger);
            }

            await Task.Delay((int)Delay.DataLoading);

            _isLoading = false;

            await Task.CompletedTask;
        }

        private async ValueTask<ItemsProviderResult<TrackingInventoryMopDto>> LoadTrackingInventoryMops(ItemsProviderRequest request)
        {
            IDateTimeRange dateTimeRange = new DateTimeRange();
            dateTimeRange.Start = DateTime.Now;
            dateTimeRange.End = DateTime.Now;

            _trackingInventoryMopDto = await _trackingInventoryMopService.GetTrackingInventoryMopByDateAsync(dateTimeRange);

            await InvokeAsync(() => StateHasChanged());

            return new ItemsProviderResult<TrackingInventoryMopDto>(
                _trackingInventoryMopDto.Skip(request.StartIndex).Take(request.Count), _trackingInventoryMopDto.Count
            );
        }
    }
}
