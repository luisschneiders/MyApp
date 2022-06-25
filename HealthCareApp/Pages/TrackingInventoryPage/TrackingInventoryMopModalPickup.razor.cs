using System;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;
using TrackingInventoryLibrary.Models;

namespace HealthCareApp.Pages.TrackingInventoryPage
{
	public partial class TrackingInventoryMopModalPickup : ComponentBase
	{
        [Inject]
        private ToastService _toastService { get; set; } = default!;

        [Inject]
        private TrackingInventoryMopService _trackingInventoryMopService { get; set; } = default!;

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private TrackingInventoryMop _trackingInventoryMop { get; set; }
        private LabelMopDto _labelMopDto { get; set; }
		private Modal _modalPickup { get; set; }

		private Guid _modalPickupTarget { get; set; }
        private bool _displayValidationErrorMessages { get; set; }

        public TrackingInventoryMopModalPickup()
		{
            _trackingInventoryMop = new();
            _labelMopDto = new();
            _modalPickup = new();
		}

		public async Task OpenModalPickupAsync(LabelMopDto labelMopDto)
		{
            string pickupTime = DateTime.Now.ToString("hh:mm tt");
            string returnTime = DateTime.Now.ToShortDateString();

            _modalPickupTarget = Guid.NewGuid();
            _labelMopDto = labelMopDto;
            _trackingInventoryMop.PickupTime = DateTime.Parse(pickupTime);
            _trackingInventoryMop.ReturnTime = DateTime.Parse(returnTime);
            _trackingInventoryMop.CleanMopQuantity = labelMopDto.Quantity;
            _trackingInventoryMop.LabelMopId = labelMopDto.Id;

			await Task.FromResult(_modalPickup.Open(_modalPickupTarget));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            await _trackingInventoryMopService.AddTrackingInventoryMopAsync(_trackingInventoryMop);
            await OnSubmitSuccess.InvokeAsync();

            _toastService.ShowToast("New pickup added!", Level.Success);

            await Task.Delay((int)Delay.DataSuccess);

            await CloseModalPickupAsync();
            await Task.CompletedTask;

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationErrorMessages = true);
            await Task.CompletedTask;
        }

        private async Task CloseModalPickupAsync()
        {
            _trackingInventoryMop = new TrackingInventoryMop();

            await Task.FromResult(_modalPickup.Close(_modalPickupTarget));
            await Task.CompletedTask;
        }
    }
}
