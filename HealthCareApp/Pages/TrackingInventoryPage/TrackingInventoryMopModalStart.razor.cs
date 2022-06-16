using System;
using HealthCareApp.Components.Modal;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.TrackingInventoryPage
{
	public partial class TrackingInventoryMopModalStart : ComponentBase
	{

		private Modal _modalStart { get; set; }

		private Guid _modalStartTarget { get; set; }


		public TrackingInventoryMopModalStart()
		{
			_modalStart = new();
		}

		public async Task OpenModalStartAsync()
		{
			_modalStartTarget = Guid.NewGuid();
			await Task.FromResult(_modalStart.Open(_modalStartTarget));
			await Task.CompletedTask;
		}
	}
}

