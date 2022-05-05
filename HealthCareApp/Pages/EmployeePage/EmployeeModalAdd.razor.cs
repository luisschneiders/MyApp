using System;
using System.Threading.Tasks;
using EmployeeLibrary.Models;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.EmployeePage
{
    public partial class EmployeeModalAdd : ComponentBase
    {
        [Inject]
        private EmployeeService _employeeService { get; set; }

        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal _modalAdd { get; set; }

        private Guid _modalAddTarget { get; set; }

        private Employee _employee;

        private bool _displayValidationErrorMessages { get; set; }

        // Constructor
        public EmployeeModalAdd()
        {
            _toastService = new();
            _modalAdd = new();
            _employee = new();
        }

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            await _employeeService.AddEmployeeAsync(_employee);
            await OnSubmitSuccess.InvokeAsync();

            _toastService.ShowToast("Employee added!", Level.Success);

            await Task.Delay((int)Delay.DataSuccess);

            await CloseModalAddAsync();
            await Task.CompletedTask;
        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationErrorMessages = true);
            await Task.CompletedTask;
        }

        public async Task OpenModalAddAsync()
        {
            _modalAddTarget = Guid.NewGuid();
            await Task.FromResult(_modalAdd.Open(_modalAddTarget));
            await Task.CompletedTask;
        }

        private async Task CloseModalAddAsync()
        {
            _employee = new Employee();
            await Task.FromResult(_modalAdd.Close(_modalAddTarget));
            await Task.CompletedTask;
        }
    }
}
