using EmployeeLibrary.Models;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.EmployeePage
{
    public partial class EmployeeModalUpdate : ComponentBase
    {
        [Inject]
        private EmployeeService _employeeService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal _modalUpdate { get; set; }

        private Guid _modalUpdateTarget { get; set; }

        private Employee _employee { get; set; }

        private bool _displayValidationErrorMessages { get; set; }

        public EmployeeModalUpdate()
        {
            _toastService = new();
            _modalUpdate = new();
            _employee = new();
        }

        public async Task OpenModalUpdateAsync(Guid id)
        {
            _employee = _employeeService.GetEmployeeById(id);

            _modalUpdateTarget = id;
            await Task.FromResult(_modalUpdate.Open(_modalUpdateTarget));
            await Task.CompletedTask;
        }

        private async Task CloseModalUpdateAsync()
        {
            _employee = new Employee();
            await Task.FromResult(_modalUpdate.Close(_modalUpdateTarget));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            await _employeeService.UpdateEmployeeAsync(_employee);
            await OnSubmitSuccess.InvokeAsync();

            _toastService.ShowToast("Employee updated!", Level.Success);

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
