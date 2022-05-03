using System;
using HealthCareApp.Settings.Enum;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Spinner
{
    public partial class Spinner : ComponentBase, IDisposable
    {
        [Inject]
        private SpinnerService _spinnerService { get; set; }

        [Parameter]
        public Size Size { get; set; }

        private AppSettings _appSettings { get; set; }

        private string _componentSize { get; set; }

        private bool _isVisible { get; set; }

        public Spinner()
        {
            _spinnerService = new();
            _appSettings = new();
            _componentSize = string.Empty;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _spinnerService.OnShow += ShowSpinner;
            _spinnerService.OnHide += HideSpinner;

            _appSettings.BuildSize(Size);
            _componentSize = _appSettings.ComponentSize;
        }

        public void ShowSpinner()
        {
            _isVisible = true;
            InvokeAsync(() => StateHasChanged());
        }

        public void HideSpinner()
        {
            _isVisible = false;
            InvokeAsync(() => StateHasChanged());
        }

        public void Dispose()
        {
            _spinnerService.OnShow -= ShowSpinner;
            _spinnerService.OnHide -= HideSpinner;
        }
    }
}
