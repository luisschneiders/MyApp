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

        private Employee _employee = new();

        private bool DisplayValidationErrorMessages { get; set; }

        private async Task HandleValidSubmitAsync()
        {
            DisplayValidationErrorMessages = false;

            await EmployeeService.AddEmployeeAsync(_employee);
            await OnSubmitSuccess.InvokeAsync();

            ToastService.ShowToast("Employee added!", Level.Success);

            await Task.Delay((int)Delay.DataSuccess);
            await Task.FromResult(_employee = new Employee());

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(DisplayValidationErrorMessages = true);
        }

        public async Task OpenModalAddAsync()
        {
            ModalAddTarget = Guid.NewGuid();
            await Task.FromResult(ModalAdd.Open(ModalAddTarget));
        }

        private async Task CloseModalAddAsync()
        {
            await Task.FromResult(ModalAdd.Close(ModalAddTarget));
        }
    }
}
