using EmployeeLibrary.Models;
using HealthCareApp.Components.OffCanvas;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using Microsoft.AspNetCore.Components;
using HealthCareApp.Settings.Enum;

namespace HealthCareApp.Pages.EmployeePage
{
	public partial class EmployeeOffCanvas : ComponentBase
	{
        [Inject]
        private EmployeeService _employeeService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private OffCanvas _offCanvas { get; set; }
        private Guid _offCanvasTarget { get; set; }

        private Employee _employee { get; set; }

        private bool _displayValidationErrorMessages { get; set; }

        private OffCanvasViewType _offCanvasViewType { get; set; }
        private string _badgeBackground { get; set; }

        public EmployeeOffCanvas()
		{
            _toastService = new();
            _offCanvas = new();
            _employee = new();
            _badgeBackground = Level.Info.ToString().ToLower();
            _displayValidationErrorMessages = false;
        }

        public async Task AddRecordOffCanvasAsync()
        {
            _employee = new();

            await Task.FromResult(SetOffCanvasState(OffCanvasViewType.Add, Level.Success));

            await Task.FromResult(_offCanvas.Open(Guid.NewGuid()));
            await Task.CompletedTask;
        }

        public async Task ViewDetailsOffCanvasAsync(Guid id)
        {
            await Task.FromResult(SetOffCanvasState(OffCanvasViewType.View, Level.Info));
            await Task.FromResult(SetOffCanvasInfo(id));

            await Task.FromResult(_offCanvas.Open(_offCanvasTarget));
            await Task.CompletedTask;
        }

        public async Task EditDetailsOffCanvasAsync(Guid id)
        {
            await Task.FromResult(SetOffCanvasState(OffCanvasViewType.Edit, Level.Danger));
            await Task.FromResult(SetOffCanvasInfo(id));

            await Task.FromResult(_offCanvas.Open(_offCanvasTarget));
            await Task.CompletedTask;
        }

        private async Task SetOffCanvasState(OffCanvasViewType offCanvasViewType, Level level)
        {
            _offCanvasViewType = offCanvasViewType;
            _badgeBackground = level.ToString().ToLower();

            await Task.CompletedTask;
        }

        private async Task SetOffCanvasInfo(Guid id)
        {
            _offCanvasTarget = id;
            _employee = _employeeService.GetEmployeeById(id);

            await Task.CompletedTask;
        }

        private async Task CloseOffCanvasAsync()
        {
            _employee = new Employee();

            await Task.FromResult(_offCanvas.Close(_offCanvasTarget));
            await Task.CompletedTask;
        }

        private async Task UpdateFormState(OffCanvasViewType offCanvasViewType, Level level)
        {
            await Task.FromResult(SetOffCanvasState(offCanvasViewType, level));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            if (_offCanvasViewType == OffCanvasViewType.Add)
            {
                await _employeeService.AddEmployeeAsync(_employee);

                _toastService.ShowToast("Employee added!", Level.Success);
            }
            else if (_offCanvasViewType == OffCanvasViewType.Edit)
            {
                await _employeeService.UpdateEmployeeAsync(_employee);

                _toastService.ShowToast("Employee updated!", Level.Success);
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
    }
}
