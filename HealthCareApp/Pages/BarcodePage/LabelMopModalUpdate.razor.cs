using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.BarcodePage
{
	public partial class LabelMopModalUpdate : ComponentBase
	{
        [Inject]
        private LabelMopService _labelMopService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal _modalUpdate { get; set; }

        private Guid _modalUpdateTarget { get; set; }

        private LabelMop _labelMop { get; set; }

        private bool _displayValidationErrorMessages { get; set; }

        public LabelMopModalUpdate()
		{
            _toastService = new();
            _modalUpdate = new();
            _labelMop = new();
        }

        public async Task OpenModalUpdateAsync(Guid id)
        {
            _labelMop = _labelMopService.GetLabelMopById(id);

            _modalUpdateTarget = id;
            await Task.FromResult(_modalUpdate.Open(_modalUpdateTarget));
            await Task.CompletedTask;
        }

        private async Task CloseModalUpdateAsync()
        {
            _labelMop = new LabelMop();
            await Task.FromResult(_modalUpdate.Close(_modalUpdateTarget));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            await _labelMopService.UpdateLabelMopAsync(_labelMop);
            await OnSubmitSuccess.InvokeAsync();

            _toastService.ShowToast("Label updated!", Level.Success);

            await Task.Delay((int)Delay.DataSuccess);

            await CloseModalUpdateAsync();
            await Task.CompletedTask;

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationErrorMessages = true);
            await Task.CompletedTask;
        }
    }
}
