using LabelLibrary.Models;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace HealthCareApp.Pages.BarcodePage
{
    public partial class LabelMopMain : ComponentBase
    {
        [Inject]
        private LabelMopService _labelMopService { get; set; } = default!;

        [Inject]
        private SpinnerService _spinnerService { get; set; }

        private Virtualize<LabelMopDto> _virtualizeContainer { get; set; }

        private bool _isSearchResults { get; set; }
        private bool _isLoading { get; set; }

        private string _searchTerm { get; set; }

        private LabelMopDto? _labelMopDetails { get; set; }
        private List<LabelMopDto> _results { get; set; }
        private List<LabelMopDto> _labelMopsDetailsDto { get; set; }

        /*
         * Add component LabelMopModalAdd & LabelMopModalUpdate reference
         */
        private LabelMopModalAdd _labelMopModalAdd { get; set; }
        private LabelMopModalUpdate _labelMopModalUpdate { get; set; }

        public LabelMopMain()
        {
            _searchTerm = string.Empty;

            _spinnerService = new();
            _virtualizeContainer = new();
            _labelMopModalAdd = new();
            _labelMopModalUpdate = new();

            _labelMopsDetailsDto = new List<LabelMopDto>();
            _results = new List<LabelMopDto>();

            _labelMopDetails = null;
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

        private async Task SearchLabelMopAsync(ChangeEventArgs eventArgs)
        {
            var searchTerm = eventArgs?.Value?.ToString();
            _isSearchResults = true;

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                _results = new List<LabelMopDto>();
                _isSearchResults = false;
                await Task.CompletedTask;
            }
            else
            {
                _results = await _labelMopService.SearchAsync(searchTerm);
                await Task.CompletedTask;
            }
        }

        private async Task OpenModalAddAsync()
        {
            await Task.FromResult(_labelMopModalAdd.OpenModalAddAsync());
            await Task.CompletedTask;
        }

        private async Task OpenModalUpdateAsync(Guid id)
        {
            await Task.FromResult(_labelMopModalUpdate.OpenModalUpdateAsync(id));
            await Task.CompletedTask;
        }

        private async Task ShowLabelMopDetails(LabelMopDto labelMopDto)
        {
            _labelMopDetails = labelMopDto;

            _isLoading = true;
            await Task.Delay((int)Delay.DataLoading);
            _isLoading = false;

            await Task.CompletedTask;
        }

        private async Task UpdateLabelMopStatusAsync(LabelMopDto labelMopDto)
        {
            labelMopDto.IsActive = !labelMopDto.IsActive;

            LabelMop labelMop = new()
            {
                Id = labelMopDto.Id,
                IsActive = labelMopDto.IsActive
            };

            await Task.FromResult(_labelMopService.UpdateLabelMopStatusAsync(labelMop));
            await Task.CompletedTask;
        }

        private async Task RefreshVirtualizeContainer()
        {
            _labelMopDetails = null;
            await _virtualizeContainer.RefreshDataAsync();
        }

        private async ValueTask<ItemsProviderResult<LabelMopDto>> LoadLabelMops(ItemsProviderRequest request)
        {
            _labelMopsDetailsDto = await _labelMopService.GetLabelMopsAsync();

            await Task.Run(() => _spinnerService.HideSpinner());

            await InvokeAsync(() => StateHasChanged());

            return new ItemsProviderResult<LabelMopDto>(
                _labelMopsDetailsDto.Skip(request.StartIndex).Take(request.Count), _labelMopsDetailsDto.Count
            );
        }
    }
}
