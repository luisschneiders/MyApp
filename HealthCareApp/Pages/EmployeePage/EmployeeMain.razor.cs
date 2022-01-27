using System;
using System.Linq;
using System.Threading.Tasks;
using EmployeeLibrary.Models;
using HealthCareApp.Components.Modal;
using HealthCareApp.Components.Toast;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace HealthCareApp.Pages.EmployeePage
{
    public partial class EmployeeMain
    {
        [Inject]
        EmployeeService EmployeeService { get; set; }

        [Inject]
        ToastService ToastService { get; set; }

        [Parameter]
        public Guid EmployeeId { get; set; } = Guid.Empty;

        private Modal ModalAddEmployee { get; set; }
        private Guid ModalAddEmployeeTarget { get; set; }
        private Virtualize<Employee> VirtualizeContainer { get; set; }

        private Employee _employee = new();

        private bool DisplayValidationErrorMessages { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {

            await base.OnInitializedAsync();
        }

        private async Task HandleValidSubmitAsync()
        {
            DisplayValidationErrorMessages = false;

            await EmployeeService.AddEmployeeAsync(_employee);
            await VirtualizeContainer.RefreshDataAsync();
            await InvokeAsync(() => StateHasChanged());

            ToastService.ShowToast("Employee added!", Level.Success);

            await Task.Delay((int)Delay.dataSuccess);
            await Task.FromResult(_employee = new Employee());

        }

        private async Task HandleInvalidSubmitAsync()
        {
            await Task.FromResult(DisplayValidationErrorMessages = true);
        }

        private async Task OpenModalAddEmployeeAsync()
        {
            ModalAddEmployeeTarget = Guid.NewGuid();
            await Task.FromResult(ModalAddEmployee.Open(ModalAddEmployeeTarget));
        }

        private async Task CloseModalAddEmployeeAsync()
        {
            await Task.FromResult(ModalAddEmployee.Close(ModalAddEmployeeTarget));
        }

        private async ValueTask<ItemsProviderResult<Employee>> LoadEmployees(ItemsProviderRequest request)
        {
            var employees = await EmployeeService.GetEmployeesAsync();

            return new ItemsProviderResult<Employee>(
                employees.Skip(request.StartIndex).Take(request.Count), employees.Count
            );
        }
    }
}
