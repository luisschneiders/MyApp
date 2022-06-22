using System;
using HealthCareApp.Components.Modal;
using HealthCareApp.Data;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;
using TrackingInventoryLibrary.Models;

namespace HealthCareApp.Pages.TrackingInventoryPage
{
	public partial class TrackingInventoryMopModalPickup : ComponentBase
	{

        //[Inject]
        //private LabelMopService _labelMopService { get; set; } = default!;

		private TrackingInventoryMop _trackingInventoryMop { get; set; }
        private LabelMopDto _labelMopDto { get; set; }
		private Modal _modalPickup { get; set; }

		private Guid _modalPickupTarget { get; set; }


		public TrackingInventoryMopModalPickup()
		{
            _trackingInventoryMop = new();
            _labelMopDto = new();
            _modalPickup = new();
		}

		public async Task OpenModalPickupAsync(LabelMopDto labelMopDto)
		{
            string timeNow = DateTime.Now.ToString("hh:mm tt");

            _modalPickupTarget = Guid.NewGuid();
            _labelMopDto = labelMopDto;
            _trackingInventoryMop.PickupTime = DateTime.Parse(timeNow);
            _trackingInventoryMop.CleanMopQuantity = labelMopDto.Quantity;

			await Task.FromResult(_modalPickup.Open(_modalPickupTarget));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            //_displayValidationErrorMessages = false;

            //await _employeeService.UpdateEmployeeAsync(_employee);
            //await OnSubmitSuccess.InvokeAsync();

            //_toastService.ShowToast("Employee updated!", Level.Success);

            //await Task.Delay((int)Delay.DataSuccess);

            //await CloseModalUpdateAsync();
            await Task.CompletedTask;

        }

        private async Task HandleInvalidSubmitAsync()
        {
            //await Task.FromResult(_displayValidationErrorMessages = true);
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
