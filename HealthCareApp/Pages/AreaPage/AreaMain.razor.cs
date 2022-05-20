using AreaLibrary.Models;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace HealthCareApp.Pages.AreaPage
{
	public partial class AreaMain : ComponentBase
	{
        [Inject]
        private AreaService _areaService { get; set; }

        [Inject]
        private SpinnerService _spinnerService { get; set; }

        private Virtualize<AreaDto> _virtualizeContainer { get; set; }

        private bool _isSearchResults { get; set; }
        private bool _isLoading { get; set; }

        private string _searchTerm { get; set; }

        private AreaDto? _areaDetails { get; set; }
        private List<AreaDto> _results { get; set; }
        private List<AreaDto> _areasDetailsDto { get; set; }

        /*
         * Add component ModalAdd & ModalUpdate reference
         */
        private AreaModalAdd _areaModalAdd { get; set; }
        private AreaModalUpdate _areaModalUpdate { get; set; }

        public AreaMain()
		{
            _searchTerm = string.Empty;

            _spinnerService = new();
            _virtualizeContainer = new();
            _areaModalAdd = new();
            _areaModalUpdate = new();

            _areasDetailsDto = new List<AreaDto>();
            _results = new List<AreaDto>();

            _areaDetails = null;
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

        private async Task SearchAreaAsync(ChangeEventArgs eventArgs)
        {
            var searchTerm = eventArgs?.Value?.ToString();
            _isSearchResults = true;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                _results = new List<AreaDto>();
                _isSearchResults = false;
                await Task.CompletedTask;
            }
            else
            {
                _results = await _areaService.SearchAsync(searchTerm);
                await Task.CompletedTask;
            }
        }

        private async Task OpenModalAddAsync()
        {
            await Task.FromResult(_areaModalAdd.OpenModalAddAsync());
            await Task.CompletedTask;
        }

        private async Task OpenModalUpdateAsync(Guid id)
        {
            //await Task.FromResult(_areaModalUpdate.OpenModalUpdateAsync(id));
            await Task.CompletedTask;
        }

        private async Task ShowAreaDetails(AreaDto areaDto)
        {
            _areaDetails = areaDto;

            _isLoading = true;
            await Task.Delay((int)Delay.DataLoading);
            _isLoading = false;

            await Task.CompletedTask;
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

        private async Task RefreshVirtualizeContainer()
        {
            _areaDetails = null;
            await _virtualizeContainer.RefreshDataAsync();
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
    }
}
