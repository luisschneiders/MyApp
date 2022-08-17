using System;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;
using TrackingInventoryLibrary.Models;

namespace HealthCareApp.Pages.TaskPage
{
	public partial class TaskMopUsageModal : ComponentBase
	{
        [Inject]
        private ToastService _toastService { get; set; } = default!;

        [Inject]
        private TrackingInventoryMopService _trackingInventoryMopService { get; set; } = default!;

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private TrackingInventoryMop _trackingInventoryMop { get; set; }
        private LabelMopDto _labelMopDto { get; set; }
		private Modal _modal { get; set; }

		private Guid _modalTarget { get; set; }
        private bool _displayValidationErrorMessages { get; set; }
        private bool _recordExists { get; set; }

        private EntryType[] _entryTypes { get; set; } = default!;
        private ShiftType[] _shiftTypes { get; set; } = default!;

        public TaskMopUsageModal()
		{
            _trackingInventoryMop = new();
            _labelMopDto = new();
            _modal = new();

            _displayValidationErrorMessages = false;
            _recordExists = true;

            _entryTypes = (EntryType[])Enum.GetValues(typeof(EntryType));
            _shiftTypes = (ShiftType[])Enum.GetValues(typeof(ShiftType));
        }

		public async Task OpenModalAsync(LabelMopDto labelMopDto)
		{
            string scanTime = DateTime.Now.ToString("hh:mm tt");

            _modalTarget = Guid.NewGuid();
            _labelMopDto = labelMopDto;
            _trackingInventoryMop.ScanTime = DateTime.Parse(scanTime);
            _trackingInventoryMop.CleanMopQuantity = labelMopDto.Quantity;
            _trackingInventoryMop.LabelMopId = labelMopDto.Id;

			await Task.FromResult(_modal.Open(_modalTarget));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            _recordExists = await _trackingInventoryMopService.CheckRecordExists(_trackingInventoryMop);

            if (_recordExists)
            {
                _toastService.ShowToast($"Barcode already has a record for {Enum.GetName(typeof(EntryType), _trackingInventoryMop.EntryType)} time!", Level.Danger);
                return;
            }
            else
            {
                await _trackingInventoryMopService.AddTrackingInventoryMopAsync(_trackingInventoryMop);
                await OnSubmitSuccess.InvokeAsync();

                _toastService.ShowToast("New record added!", Level.Success);

                await Task.Delay((int)Delay.DataSuccess);
                await CloseModalAsync();
            }


            await Task.CompletedTask;

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationErrorMessages = true);
            await Task.CompletedTask;
        }

        private async Task CloseModalAsync()
        {
            _trackingInventoryMop = new TrackingInventoryMop();

            await Task.FromResult(_modal.Close(_modalTarget));
            await Task.CompletedTask;
        }
    }
}
