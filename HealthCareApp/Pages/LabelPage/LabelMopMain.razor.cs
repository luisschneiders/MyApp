using LabelLibrary.Models;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Data;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace HealthCareApp.Pages.LabelPage
{
    public partial class LabelMopMain : ComponentBase
    {
        [Inject]
        private LabelMopService _labelMopService { get; set; }

        [Inject]
        private SpinnerService _spinnerService { get; set; }

        private Virtualize<LabelMop> _virtualizeContainer { get; set; }

        private bool _isSearchResults { get; set; }
        private bool _isLoading { get; set; }

        private string _searchTerm { get; set; }

        private LabelMop? _labelMopDetails { get; set; }
        private List<LabelMop> _results { get; set; }
        private List<LabelMop> _labelMops { get; set; }

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

            _labelMops = new List<LabelMop>();
            _results = new List<LabelMop>();

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
                _results = new List<LabelMop>();
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

        private async Task ShowLabelMopDetails(LabelMop labelMop)
        {
            _labelMopDetails = labelMop;

            _isLoading = true;
            await Task.Delay((int)Delay.DataLoading);
            _isLoading = false;

            await Task.CompletedTask;
        }

        private async Task UpdateLabelMopStatusAsync(LabelMop labelMop)
        {
            labelMop.IsActive = !labelMop.IsActive;
            await Task.FromResult(_labelMopService.UpdateLabelMopAsync(labelMop));
            await Task.CompletedTask;
        }

        private async Task RefreshVirtualizeContainer()
        {
            _labelMopDetails = null;
            await _virtualizeContainer.RefreshDataAsync();
        }

        private async ValueTask<ItemsProviderResult<LabelMop>> LoadLabelMops(ItemsProviderRequest request)
        {
            _labelMops = await _labelMopService.GetLabelMopsAsync();

            await Task.Run(() => _spinnerService.HideSpinner());

            await InvokeAsync(() => StateHasChanged());

            return new ItemsProviderResult<LabelMop>(
                _labelMops.Skip(request.StartIndex).Take(request.Count), _labelMops.Count
            );
        }
    }
}
