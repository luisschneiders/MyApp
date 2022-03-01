using System;
using System.Linq;
using System.Threading.Tasks;
using EmployeeLibrary.Models;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace HealthCareApp.Pages.EmployeePage
{
    public partial class EmployeeMain : ComponentBase
    {
        [Inject]
        private EmployeeService EmployeeService { get; set; }

        [Inject]
        private SpinnerService SpinnerService { get; set; }

        [Parameter]
        public Guid EmployeeId { get; set; } = Guid.Empty;

        private Virtualize<Employee> VirtualizeContainer { get; set; }

        private Employee EmployeeDetails { get; set; }

        private bool IsLoading { get; set; }

        /*
         * Add component EmployeeModalAdd & EmployeeModalUpdate reference
         */
        private EmployeeModalAdd EmployeeModalAdd { get; set; }
        private EmployeeModalUpdate EmployeeModalUpdate { get; set; }

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

        private async Task OpenModalAddAsync()
        {
            await Task.FromResult(EmployeeModalAdd.OpenModalAddAsync());
            await Task.CompletedTask;
        }

        private async Task OpenModalUpdateAsync(Guid id)
        {
            await Task.FromResult(EmployeeModalUpdate.OpenModalUpdateAsync(id));
            await Task.CompletedTask;
        }

        private async Task ShowEmployeeDetails(Employee employee)
        {

            EmployeeDetails = employee;

            IsLoading = true;
            await Task.Delay((int)Delay.DataLoading);
            IsLoading = false;

            await Task.CompletedTask;
        }

        private async ValueTask<ItemsProviderResult<Employee>> LoadEmployees(ItemsProviderRequest request)
        {
            var employees = await EmployeeService.GetEmployeesAsync();

            await Task.Run(() => SpinnerService.HideSpinner());

            await InvokeAsync(() => StateHasChanged());
            return new ItemsProviderResult<Employee>(
                employees.Skip(request.StartIndex).Take(request.Count), employees.Count
            );
        }

        private async Task RefreshVirtualizeContainer()
        {
            EmployeeDetails = null;
            await VirtualizeContainer.RefreshDataAsync();
        }

        public async Task VirtualizeContainerAsync()
        {
            await RefreshVirtualizeContainer();
            await Task.CompletedTask;
        }
    }
}
