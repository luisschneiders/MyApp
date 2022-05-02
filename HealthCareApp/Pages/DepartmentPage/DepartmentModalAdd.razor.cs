using System;
using DepartmentLibrary.Models;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.DepartmentPage
{
    public partial class DepartmentModalAdd : ComponentBase
    {

        [Inject]
        private DepartmentService DepartmentService { get; set; }

        [Inject]
        private ToastService ToastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal ModalAdd { get; set; }

        private Guid ModalAddTarget { get; set; }

        private Department department;

        private bool DisplayValidationErrorMessages { get; set; }

        public DepartmentModalAdd()
        {
            department = new();
        }

        public async Task OpenModalAddAsync()
        {
            ModalAddTarget = Guid.NewGuid();
            await Task.FromResult(ModalAdd.Open(ModalAddTarget));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            DisplayValidationErrorMessages = false;

            await DepartmentService.AddDepartmentAsync(department);
            await OnSubmitSuccess.InvokeAsync();

            ToastService.ShowToast("Department added!", Level.Success);

            await Task.Delay((int)Delay.DataSuccess);

            await CloseModalAddAsync();
            await Task.CompletedTask;
        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(DisplayValidationErrorMessages = true);
            await Task.CompletedTask;
        }

        private async Task CloseModalAddAsync()
        {
            department = new Department();
            await Task.FromResult(ModalAdd.Close(ModalAddTarget));
            await Task.CompletedTask;
        }

    }
}
