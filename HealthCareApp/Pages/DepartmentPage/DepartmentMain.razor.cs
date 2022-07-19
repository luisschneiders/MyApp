using AreaLibrary.Models;
using DepartmentLibrary.Models;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Data;
using HealthCareApp.Pages.EmployeePage;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace HealthCareApp.Pages.DepartmentPage
{
    public partial class DepartmentMain : ComponentBase
    {
        [Inject]
        private AreaService _areaService { get; set; } = default!;

        [Inject]
        private DepartmentService _departmentService { get; set; } = default!;

        [Inject]
        private SpinnerService _spinnerService { get; set; }

        private Virtualize<AreaDto> _virtualizeContainer { get; set; }

        private bool _isSearchResults { get; set; }

        private string _searchTerm { get; set; }

        private List<AreaDto> _areaDtoResults { get; set; }
        private List<AreaDto> _areasDetailsDto { get; set; }

        //private List<Department> _departmentResults { get; set; }
        private List<Department> _departments { get; set; }

        /*
         * Add component AreaOffCanvas & DepartmentModal reference
         */
        private AreaOffCanvas _areaOffCanvas { get; set; }
        private DepartmentModal _departmentModal { get; set; }

        public DepartmentMain()
        {
            _isSearchResults = false;
            _searchTerm = string.Empty;

            _spinnerService = new();
            _virtualizeContainer = new();
            //_departmentModalAdd = new();
            //_departmentModalUpdate = new();

            _areaOffCanvas = new();
            _departmentModal = new();

            _areaDtoResults = new();
            _areasDetailsDto = new();

            _departments = new List<Department>();
            //_departmentResults = new List<Department>();

            //_departmentDetails = null;
        }

        private async Task AddAreaAsync()
        {
            await Task.FromResult(_areaOffCanvas.AddRecordOffCanvasAsync());
            await Task.CompletedTask;
        }

        private async Task ViewDepartmentAsync()
        {
            await Task.FromResult(_departmentModal.OpenModalAsync());
            await Task.CompletedTask;
        }

        private async Task ViewDetailsAsync(Guid id)
        {
            await Task.FromResult(_areaOffCanvas.ViewDetailsOffCanvasAsync(id));
            await Task.CompletedTask;
        }

        private async Task EditDetailsAsync(Guid id)
        {
            await Task.FromResult(_areaOffCanvas.EditDetailsOffCanvasAsync(id));
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

        private async ValueTask<ItemsProviderResult<AreaDto>> LoadAreas(ItemsProviderRequest request)
        {
            _areasDetailsDto = await _areaService.GetAreasAsync();

            await Task.Run(() => _spinnerService.HideSpinner());

            await InvokeAsync(() => StateHasChanged());

            return new ItemsProviderResult<AreaDto>(
                _areasDetailsDto.Skip(request.StartIndex).Take(request.Count), _areasDetailsDto.Count
            );
        }

        private async Task UpdateAreaStatusAsync(AreaDto areaDto)
        {
            areaDto.IsActive = !areaDto.IsActive;

            Area area = new()
            {
                Id = areaDto.Id,
                IsActive = areaDto.IsActive
            };

            await Task.FromResult(_areaService.UpdateAreaStatusAsync(area));
            await Task.CompletedTask;
        }

        private async Task SearchAsync(ChangeEventArgs eventArgs)
        {
            var searchTerm = eventArgs?.Value?.ToString();
            _isSearchResults = true;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                _areaDtoResults = new List<AreaDto>();
                _isSearchResults = false;
                await Task.CompletedTask;
            }
            else
            {
                _areaDtoResults = await _areaService.SearchAsync(searchTerm);
                await Task.CompletedTask;
            }
        }

        //private async Task OpenModalAddAsync()
        //{
        //    await Task.FromResult(_departmentModalAdd.OpenModalAddAsync());
        //    await Task.CompletedTask;
        //}

        //private async Task OpenModalUpdateAsync(Guid id)
        //{
        //    await Task.FromResult(_departmentModalUpdate.OpenModalUpdateAsync(id));
        //    await Task.CompletedTask;
        //}

        //private async Task ShowDepartmentDetails(Department department)
        //{
        //    _departmentDetails = department;

        //    _isLoading = true;
        //    await Task.Delay((int)Delay.DataLoading);
        //    _isLoading = false;

        //    await Task.CompletedTask;
        //}

        //private async Task UpdateDepartmentStatusAsync(Department department)
        //{
        //    department.IsActive = !department.IsActive;
        //    await Task.FromResult(_departmentService.UpdateDepartmentAsync(department));
        //    await Task.CompletedTask;
        //}

        private async Task RefreshVirtualizeContainer()
        {
            await _virtualizeContainer.RefreshDataAsync();
        }

        //private async ValueTask<ItemsProviderResult<Department>> LoadDepartments(ItemsProviderRequest request)
        //{
        //    _departments = await _departmentService.GetDepartmentsAsync();

        //    await Task.Run(() => _spinnerService.HideSpinner());

        //    await InvokeAsync(() => StateHasChanged());

        //    return new ItemsProviderResult<Department>(
        //        _departments.Skip(request.StartIndex).Take(request.Count), _departments.Count
        //    );
        //}
    }
}
