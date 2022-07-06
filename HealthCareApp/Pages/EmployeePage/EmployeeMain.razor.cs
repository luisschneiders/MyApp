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
        private EmployeeService _employeeService { get; set; } = default!;

        [Inject]
        private SpinnerService _spinnerService { get; set; }

        private Virtualize<EmployeeListDto> _virtualizeContainer { get; set; }

        private bool _isLoading { get; set; }
        private bool _isSearchResults { get; set; }

        private string _searchTerm { get; set; }

        private Employee? _employeeDetails { get; set; }

        private List<EmployeeListDto> _employeeListDto { get; set; }
        private List<EmployeeListDto> _results { get; set; }

        /*
         * Add component EmployeeModalAdd & EmployeeModalUpdate reference
         */
        private EmployeeModalAdd _employeeModalAdd { get; set; }
        private EmployeeModalUpdate _employeeModalUpdate { get; set; }

        public EmployeeMain()
        {
            _searchTerm = string.Empty;

            _spinnerService = new();
            _virtualizeContainer = new();
            _employeeModalAdd = new();
            _employeeModalUpdate = new();

            _employeeListDto = new();
            _results = new List<EmployeeListDto>();

            _employeeDetails = null;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Run(() => _spinnerService.ShowSpinner());
                await Task.CompletedTask;
            }
            else
            {
                await Task.Run(() => _spinnerService.HideSpinner());
                await Task.CompletedTask;
            }

        }

        private async Task OpenModalAddAsync()
        {
            await Task.FromResult(_employeeModalAdd.OpenModalAddAsync());
            await Task.CompletedTask;
        }

        private async Task OpenModalUpdateAsync(Guid id)
        {
            await Task.FromResult(_employeeModalUpdate.OpenModalUpdateAsync(id));
            await Task.CompletedTask;
        }

        private async Task ShowEmployeeDetails(Employee employee)
        {
            _employeeDetails = employee;

            _isLoading = true;
            await Task.Delay((int)Delay.DataLoading);
            _isLoading = false;

            await Task.CompletedTask;
        }

        private async ValueTask<ItemsProviderResult<EmployeeListDto>> LoadEmployees(ItemsProviderRequest request)
        {

            _employeeListDto = await _employeeService.GetEmployeeListDtoAsync();

            await Task.Run(() => _spinnerService.HideSpinner());

            await InvokeAsync(() => StateHasChanged());

            return new ItemsProviderResult<EmployeeListDto>(
                _employeeListDto.Skip(request.StartIndex).Take(request.Count), _employeeListDto.Count
            );
        }

        private async Task RefreshVirtualizeContainer()
        {
            _employeeDetails = null;
            await _virtualizeContainer.RefreshDataAsync();
        }

        private async Task SearchEmployeeAsync(ChangeEventArgs eventArgs)
        {
            var searchTerm = eventArgs?.Value?.ToString();
            _isSearchResults = true;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                _results = new ();
                _isSearchResults = false;
                await Task.CompletedTask;
            }
            else
            {
                _results = await _employeeService.SearchEmployeeListDtoAsync(searchTerm);
                await Task.CompletedTask;
            }
        }

        private async Task UpdateEmployeeStatusAsync(EmployeeListDto employeeListDto)
        {
            employeeListDto.IsActive = !employeeListDto.IsActive;

            Employee employee = new()
            {
                Id = employeeListDto.Id,
                IsActive = employeeListDto.IsActive
            };

            await Task.FromResult(_employeeService.UpdateEmployeeStatusAsync(employee));
            await Task.CompletedTask;
        }
    }
}
