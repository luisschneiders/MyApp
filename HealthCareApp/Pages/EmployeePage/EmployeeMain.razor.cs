using EmployeeLibrary.Models;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Data;
using HealthCareApp.Shared;
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

        private bool _hasSearchResults { get; set; }

        private string _searchTerm { get; set; }

        private List<EmployeeListDto> _employeeListDto { get; set; }
        private List<EmployeeListDto> _searchResults { get; set; }

        /*
         * Add component EmployeeOffCanvas reference
         */
        private EmployeeOffCanvas _employeeOffCanvas { get; set; }

        private AppURL _appURL { get; }

        public EmployeeMain()
        {
            _searchTerm = string.Empty;

            _spinnerService = new();
            _virtualizeContainer = new();
            _employeeOffCanvas = new();

            _employeeListDto = new();
            _searchResults = new List<EmployeeListDto>();

            _hasSearchResults = false;
            _appURL = new();
        }

        private async Task AddRecordAsync()
        {
            await Task.FromResult(_employeeOffCanvas.AddRecordOffCanvasAsync());
            await Task.CompletedTask;
        }

        private async Task ViewDetailsAsync(Guid id)
        {
            await Task.FromResult(_employeeOffCanvas.ViewDetailsOffCanvasAsync(id));
            await Task.CompletedTask;
        }

        private async Task EditDetailsAsync(Guid id)
        {
            await Task.FromResult(_employeeOffCanvas.EditDetailsOffCanvasAsync(id));
            await Task.CompletedTask;
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
            await _virtualizeContainer.RefreshDataAsync();
        }

        private async Task SearchAsync(ChangeEventArgs eventArgs)
        {
            var searchTerm = eventArgs?.Value?.ToString();
            _hasSearchResults = true;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                _searchResults = new();
                _hasSearchResults = false;
                await Task.CompletedTask;
            }
            else
            {
                _searchResults = await _employeeService.SearchEmployeeListDtoAsync(searchTerm);
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
