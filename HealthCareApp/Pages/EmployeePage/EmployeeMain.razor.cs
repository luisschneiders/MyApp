using System;
using System.Linq;
using System.Threading.Tasks;
using EmployeeLibrary.Models;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Data;
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
            }
            else
            {
                await Task.Run(() => SpinnerService.HideSpinner());
            }
        }

        private async Task OpenModalAddAsync()
        {
            await Task.FromResult(EmployeeModalAdd.OpenModalAddAsync());
        }

        private async Task OpenModalUpdateAsync(Employee employee)
        {
            await Task.FromResult(EmployeeModalUpdate.OpenModalUpdateAsync(employee));
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
            await VirtualizeContainer.RefreshDataAsync();
        }
    }
}
