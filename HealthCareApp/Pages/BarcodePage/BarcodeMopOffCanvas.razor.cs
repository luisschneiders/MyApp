using System;
using EmployeeLibrary.Models;
using HealthCareApp.Components.OffCanvas;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.BarcodePage
{
    public partial class BarcodeMopOffCanvas : ComponentBase
    {
        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private OffCanvas _offCanvas { get; set; }
        private Guid _offCanvasTarget { get; set; }

        private LabelMop _labelMop { get; set; }

        private OffCanvasViewType _offCanvasViewType { get; set; }
        private string _badgeBackground { get; set; }

        private bool _displayValidationErrorMessages { get; set; }

        public BarcodeMopOffCanvas()
        {
            _toastService = new();
            _offCanvas = new();
            _labelMop = new();

            _badgeBackground = Level.Info.ToString().ToLower();
        }

        public async Task AddRecordOffCanvasAsync()
        {
            _labelMop = new();

            await Task.FromResult(SetOffCanvasState(OffCanvasViewType.Add, Level.Success));

            await Task.FromResult(_offCanvas.Open(Guid.NewGuid()));
            await Task.CompletedTask;
        }

        private async Task SetOffCanvasState(OffCanvasViewType offCanvasViewType, Level level)
        {
            _offCanvasViewType = offCanvasViewType;
            _badgeBackground = level.ToString().ToLower();

            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            if (_offCanvasViewType == OffCanvasViewType.Add)
            {
                //await _employeeService.AddEmployeeAsync(_employee);

                _toastService.ShowToast("Barcode added!", Level.Success);
            }
            else if (_offCanvasViewType == OffCanvasViewType.Edit)
            {
                //await _employeeService.UpdateEmployeeAsync(_employee);

                _toastService.ShowToast("Barcode updated!", Level.Success);
            }

            await OnSubmitSuccess.InvokeAsync();

            await Task.Delay((int)Delay.DataSuccess);

            await CloseOffCanvasAsync();
            await Task.CompletedTask;

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationErrorMessages = true);
            await Task.CompletedTask;
        }

        private async Task CloseOffCanvasAsync()
        {
            _labelMop = new();

            await Task.FromResult(_offCanvas.Close(_offCanvasTarget));
            await Task.CompletedTask;
        }

        private async Task UpdateFormState(OffCanvasViewType offCanvasViewType, Level level)
        {
            await Task.FromResult(SetOffCanvasState(offCanvasViewType, level));
            await Task.CompletedTask;
        }
    }
}
