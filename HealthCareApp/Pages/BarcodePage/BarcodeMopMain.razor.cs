using System;
using EmployeeLibrary.Models;
using MyApp.Components.Spinner;
using MyApp.Data;
using MyApp.Pages.EmployeePage;
using MyApp.Settings.Enum;
using MyApp.Shared;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace MyApp.Pages.BarcodePage
{
    public partial class BarcodeMopMain : ComponentBase
    {
        [Inject]
        private LabelMopService _labelMopService { get; set; } = default!;

        [Inject]
        private SpinnerService _spinnerService { get; set; }

        private Virtualize<LabelMopDto> _virtualizeContainer { get; set; }
        private List<LabelMopDto> _labelMopsDto { get; set; }

        private AppURL _appURL { get; }

        /*
         * Add component BarcodeMopOffCanvas reference
         */
        private BarcodeMopOffCanvas _barcodeMopOffCanvas { get; set; }

        private string _searchTerm { get; set; }
        private List<LabelMopDto> _searchResults { get; set; }
        private ShiftType[] _shiftTypes { get; set; } = default!;
        private bool _hasSearchResults { get; set; }

        public BarcodeMopMain()
        {
            _spinnerService = new();
            _virtualizeContainer = new();
            _labelMopsDto = new();
            _appURL = new();
            _barcodeMopOffCanvas = new();
            _searchTerm = string.Empty;
            _searchResults = new List<LabelMopDto>();
            _shiftTypes = (ShiftType[])Enum.GetValues(typeof(ShiftType));
            _hasSearchResults = false;
        }

        private async Task AddRecordAsync()
        {
            await Task.FromResult(_barcodeMopOffCanvas.AddRecordOffCanvasAsync());
            await Task.CompletedTask;
        }

        private async Task ViewDetailsAsync(Guid id)
        {
            await Task.FromResult(_barcodeMopOffCanvas.ViewDetailsOffCanvasAsync(id));
            await Task.CompletedTask;
        }

        private async Task EditDetailsAsync(Guid id)
        {
            await Task.FromResult(_barcodeMopOffCanvas.EditDetailsOffCanvasAsync(id));
            await Task.CompletedTask;
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
                _searchResults = await _labelMopService.SearchAsync(searchTerm);
                await Task.CompletedTask;
            }
        }

        private async Task RefreshVirtualizeContainer()
        {
            await _virtualizeContainer.RefreshDataAsync();
        }

        private async ValueTask<ItemsProviderResult<LabelMopDto>> LoadLabelMops(ItemsProviderRequest request)
        {
            _labelMopsDto = await _labelMopService.GetLabelMopsAsync();

            await Task.Run(() => _spinnerService.HideSpinner());

            await InvokeAsync(() => StateHasChanged());

            return new ItemsProviderResult<LabelMopDto>(
                _labelMopsDto.Skip(request.StartIndex).Take(request.Count), _labelMopsDto.Count
            );
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
    }
}
