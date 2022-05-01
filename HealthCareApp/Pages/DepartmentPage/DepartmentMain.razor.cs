using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepartmentLibrary.Models;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
 

namespace HealthCareApp.Pages.DepartmentPage
{
    public partial class DepartmentMain : ComponentBase
    {
        [Inject]
        private DepartmentService DepartmentService { get; set; }

        [Inject]
        private SpinnerService SpinnerService { get; set; }

        private Virtualize<Department> VirtualizeContainer { get; set; }

        private Department DepartmentDetails { get; set; }

        private bool IsLoading { get; set; }

        private string SearchTerm { get; set; }

        private List<Department> Results { get; set; }
        private List<Department> Departments { get; set; }

        /*
         * Add component DepartmentModalAdd & DepartmentModalUpdate reference
         */
        private DepartmentModalAdd DepartmentModalAdd { get; set; }
        private DepartmentModalUpdate DepartmentModalUpdate { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Run(() => SpinnerService.ShowSpinner());
                await Task.CompletedTask;
            }
            else
            {
                await Task.Run(() => SpinnerService.HideSpinner());
                await Task.CompletedTask;
            }
        }

        private async Task SearchDepartmentAsync(ChangeEventArgs eventArgs)
        {
            var searchTerm = eventArgs.Value.ToString();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                Results = await DepartmentService.SearchAsync(searchTerm);
            }
            else
            {
                Results = null;
            }
        }

        private async Task OpenModalAddAsync()
        {
            await Task.FromResult(DepartmentModalAdd.OpenModalAddAsync());
            await Task.CompletedTask;
        }

        private async Task OpenModalUpdateAsync(Guid id)
        {
            await Task.FromResult(DepartmentModalUpdate.OpenModalUpdateAsync(id));
            await Task.CompletedTask;
        }

        private async Task ShowDepartmentDetails(Department department)
        {
            DepartmentDetails = department;
            IsLoading = true;
            await Task.Delay((int)Delay.DataLoading);
            IsLoading = false;

            await Task.CompletedTask;
        }

        private async Task UpdateDepartmentStatusAsync(Department department)
        {
            department.IsActive = !department.IsActive;
            await Task.FromResult(DepartmentService.UpdateDepartmentAsync(department));
            await Task.CompletedTask;
        }

        private async Task RefreshVirtualizeContainer()
        {
            DepartmentDetails = null;
            await VirtualizeContainer.RefreshDataAsync();
        }

        private async ValueTask<ItemsProviderResult<Department>> LoadDepartments(ItemsProviderRequest request)
        {
            Departments = await DepartmentService.GetDepartmentsAsync();

            await Task.Run(() => SpinnerService.HideSpinner());

            await InvokeAsync(() => StateHasChanged());
            return new ItemsProviderResult<Department>(
                Departments.Skip(request.StartIndex).Take(request.Count), Departments.Count
            );

        }
    }
}
