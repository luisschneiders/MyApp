using System;
using System.Linq;
using System.Threading.Tasks;
using EmployeeLibrary.Models;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace HealthCareApp.Pages.EmployeePage
{
    public partial class EmployeeMain
    {
        [Parameter]
        public Guid EmployeeId { get; set; } = Guid.Empty;

        private Modal _modalAddEmployee { get; set; }
        private Guid _modalAddEmployeeTarget { get; set; }
        private Virtualize<Employee> VirtualizeContainer { get; set; }

        private Employee _employee = new Employee();

        private bool _displayValidationErrorMessages { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {

            await base.OnInitializedAsync();
        }

        private async Task HandleValidSubmitAsync()
        {
            toastService.ShowToast("Employee added!", ToastLevel.Success);
            await Task.FromResult(_displayValidationErrorMessages = false);

            await employeeService.AddEmployeeAsync(_employee);

            await VirtualizeContainer.RefreshDataAsync();
            await InvokeAsync(() => StateHasChanged());

            await Task.Delay((int)Delay.dataSuccess);

            await Task.FromResult(_employee = new Employee());
        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(_displayValidationErrorMessages = true);
        }

        private async Task OpenModalAddEmployeeAsync()
        {
            _modalAddEmployeeTarget = Guid.NewGuid();
            await Task.FromResult(_modalAddEmployee.Open(_modalAddEmployeeTarget));
        }

        private async Task CloseModalAddEmployeeAsync()
        {
            await Task.FromResult(_modalAddEmployee.Close(_modalAddEmployeeTarget));
        }

        private async ValueTask<ItemsProviderResult<Employee>> LoadEmployees(ItemsProviderRequest request)
        {
            var employees = await employeeService.GetEmployeesAsync();
            return new ItemsProviderResult<Employee>(employees.Skip(request.StartIndex).Take(request.Count), employees.Count());
        }
    }
}
