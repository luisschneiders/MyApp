using System;
using HealthCareApp.Components.Modal;
using HealthCareApp.Data;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;
using TrackingInventoryLibrary.Models;

namespace HealthCareApp.Pages.TrackingInventoryPage
{
	public partial class TrackingInventoryMopModalStart : ComponentBase
	{

        //[Inject]
        //private LabelMopService _labelMopService { get; set; } = default!;

		private TrackingInventoryMop _trackingInventoryMop { get; set; }
        private LabelMopDto _labelMopDto { get; set; }
		private Modal _modalStart { get; set; }

		private Guid _modalStartTarget { get; set; }


		public TrackingInventoryMopModalStart()
		{
            _trackingInventoryMop = new();
            _labelMopDto = new();
			_modalStart = new();
		}

		public async Task OpenModalStartAsync(LabelMopDto labelMopDto)
		{
			_modalStartTarget = Guid.NewGuid();
            _labelMopDto = labelMopDto;

			await Task.FromResult(_modalStart.Open(_modalStartTarget));
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
    }
}

