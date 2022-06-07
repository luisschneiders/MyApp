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
        private DepartmentService _departmentService { get; set; } = default!;

        [Inject]
        private ToastService _toastService { get; set; }

        [Parameter]
        public EventCallback OnSubmitSuccess { get; set; }

        private Modal _modalUpdate { get; set; }

        private Guid _modalUpdateTarget { get; set; }

        private Department _department { get; set; }

        private bool _displayValidationErrorMessages { get; set; }

        public DepartmentModalUpdate()
        {
            _toastService = new();
            _modalUpdate = new();
            _department = new();
        }

        public async Task OpenModalUpdateAsync(Guid id)
        {
            _department = _departmentService.GetDepartmentById(id);

            _modalUpdateTarget = id;
            await Task.FromResult(_modalUpdate.Open(_modalUpdateTarget));
            await Task.CompletedTask;
        }

        private async Task CloseModalUpdateAsync()
        {
            _department = new Department();
            await Task.FromResult(_modalUpdate.Close(_modalUpdateTarget));
            await Task.CompletedTask;
        }

        private async Task HandleValidSubmitAsync()
        {
            _displayValidationErrorMessages = false;

            await _departmentService.UpdateDepartmentAsync(_department);
            await OnSubmitSuccess.InvokeAsync();

            _toastService.ShowToast("Department updated!", Level.Success);

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
