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
        private DepartmentService _departmentService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal _modalAdd { get; set; }

        private Guid _modalAddTarget { get; set; }

        private Department _department { get; set; }

        private bool _displayValidationErrorMessages { get; set; }

        public DepartmentModalAdd()
        {
            _toastService = new();
            _modalAdd = new();
            _department = new();
        }

        public async Task OpenModalAddAsync()
        {
            _modalAddTarget = Guid.NewGuid();
            await Task.FromResult(_modalAdd.Open(_modalAddTarget));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            await _departmentService.AddDepartmentAsync(_department);
            await OnSubmitSuccess.InvokeAsync();

            _toastService.ShowToast("Department added!", Level.Success);

            await Task.Delay((int)Delay.DataSuccess);

            await CloseModalAddAsync();
            await Task.CompletedTask;
        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationErrorMessages = true);
            await Task.CompletedTask;
        }

        private async Task CloseModalAddAsync()
        {
            _department = new Department();
            await Task.FromResult(_modalAdd.Close(_modalAddTarget));
            await Task.CompletedTask;
        }
    }
}
