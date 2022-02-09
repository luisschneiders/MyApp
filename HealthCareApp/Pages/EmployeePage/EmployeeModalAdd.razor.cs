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
        private EmployeeService EmployeeService { get; set; }

        [Inject]
        private ToastService ToastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal ModalAdd { get; set; }

        private Guid ModalAddTarget { get; set; }

        private Employee employee;

        private bool DisplayValidationErrorMessages { get; set; }

        // Constructor
        public EmployeeModalAdd()
        {
            employee = new();
        }

        private async Task HandleValidSubmitAsync()
        {
            DisplayValidationErrorMessages = false;

            await EmployeeService.AddEmployeeAsync(employee);
            await OnSubmitSuccess.InvokeAsync();

            ToastService.ShowToast("Employee added!", Level.Success);

            await Task.Delay((int)Delay.DataSuccess);

            await CloseModalAddAsync();
            await Task.CompletedTask;
        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(DisplayValidationErrorMessages = true);
            await Task.CompletedTask;
        }

        public async Task OpenModalAddAsync()
        {
            ModalAddTarget = Guid.NewGuid();
            await Task.FromResult(ModalAdd.Open(ModalAddTarget));
            await Task.CompletedTask;
        }

        private async Task CloseModalAddAsync()
        {
            employee = new Employee();
            await Task.FromResult(ModalAdd.Close(ModalAddTarget));
            await Task.CompletedTask;
        }
    }
}
