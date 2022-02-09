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
    public partial class EmployeeModalUpdate : ComponentBase
    {
        [Inject]
        private EmployeeService EmployeeService { get; set; }

        [Inject]
        private ToastService ToastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal ModalUpdate { get; set; }

        private Guid ModalUpdateTarget { get; set; }

        private Employee employee;

        private bool DisplayValidationErrorMessages { get; set; }

        // Constructor
        public EmployeeModalUpdate()
        {
            employee = new();
        }

        public async Task OpenModalUpdateAsync(Employee employee)
        {
            this.employee = employee;

            ModalUpdateTarget = employee.Id;
            await Task.FromResult(ModalUpdate.Open(ModalUpdateTarget));
            await Task.CompletedTask;
        }

        private async Task CloseModalUpdateAsync()
        {
            employee = new Employee();
            await Task.FromResult(ModalUpdate.Close(ModalUpdateTarget));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            DisplayValidationErrorMessages = false;

            await EmployeeService.UpdateEmployeeAsync(employee);
            await OnSubmitSuccess.InvokeAsync();

            ToastService.ShowToast("Employee updated!", Level.Success);

            await Task.Delay((int)Delay.DataSuccess);

            await CloseModalUpdateAsync();
            await Task.CompletedTask;

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(DisplayValidationErrorMessages = true);
            await Task.CompletedTask;
        }
    }
}
