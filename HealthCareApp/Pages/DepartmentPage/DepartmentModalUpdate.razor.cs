using System;
using DepartmentLibrary.Models;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
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
    }
}
