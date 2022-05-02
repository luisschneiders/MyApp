using System;
using DepartmentLibrary.Models;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.DepartmentPage
{
    public partial class DepartmentModalUpdate : ComponentBase
    {
        [Inject]
        private DepartmentService DepartmentService { get; set; }

        [Inject]
        private ToastService ToastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal ModalUpdate { get; set; }

        private Guid ModalUpdateTarget { get; set; }

        private Department department { get; set; }

        private bool DisplayValidationErrorMessages { get; set; }

        public DepartmentModalUpdate()
        {
            department = new();
        }

        public async Task OpenModalUpdateAsync(Guid id)
        {
            department = DepartmentService.GetDepartmentById(id);

            ModalUpdateTarget = id;
            await Task.FromResult(ModalUpdate.Open(ModalUpdateTarget));
            await Task.CompletedTask;
        }

        private async Task CloseModalUpdateAsync()
        {
            department = new Department();
            await Task.FromResult(ModalUpdate.Close(ModalUpdateTarget));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            DisplayValidationErrorMessages = false;

            await DepartmentService.UpdateDepartmentAsync(department);
            await OnSubmitSuccess.InvokeAsync();

            ToastService.ShowToast("Department updated!", Level.Success);

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
