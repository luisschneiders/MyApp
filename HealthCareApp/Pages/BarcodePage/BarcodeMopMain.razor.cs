using System;
using EmployeeLibrary.Models;
using HealthCareApp.Data;
using HealthCareApp.Pages.EmployeePage;
using HealthCareApp.Shared;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace HealthCareApp.Pages.BarcodePage
{
    public partial class BarcodeMopMain : ComponentBase
    {
        [Inject]
        private LabelMopService _labelMopService { get; set; } = default!;

        private Virtualize<LabelMopDto> _virtualizeContainer { get; set; }

        private AppURL _appURL { get; }

        /*
         * Add component BarcodeMopOffCanvas reference
         */
        private BarcodeMopOffCanvas _barcodeMopOffCanvas { get; set; }

        private string _searchTerm { get; set; }
        private List<LabelMopDto> _searchResults { get; set; }
        private bool _hasSearchResults { get; set; }

        public BarcodeMopMain()
        {
            _virtualizeContainer = new();
            _appURL = new();
            _barcodeMopOffCanvas = new();
            _searchTerm = string.Empty;
            _searchResults = new List<LabelMopDto>();
            _hasSearchResults = false;
        }

        private async Task AddRecordAsync()
        {
            await Task.FromResult(_barcodeMopOffCanvas.AddRecordOffCanvasAsync());
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
    }
}
