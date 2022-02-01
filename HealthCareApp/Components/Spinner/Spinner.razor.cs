using System;
using HealthCareApp.Settings.Enum;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Spinner
{
    public partial class Spinner : ComponentBase, IDisposable
    {
        [Inject]
        private SpinnerService SpinnerService { get; set; }

        [Parameter]
        public Size Size { get; set; }

        private AppSettings AppSettings { get; set; } = new();

        private string ComponentSize { get; set; }
        private bool IsVisible { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            SpinnerService.OnShow += ShowSpinner;
            SpinnerService.OnHide += HideSpinner;

            AppSettings.BuildSize(Size);
            ComponentSize = AppSettings.ComponentSize;
        }

        public void ShowSpinner()
        {
            IsVisible = true;
            InvokeAsync(() => StateHasChanged());
        }

        public void HideSpinner()
        {
            IsVisible = false;
            InvokeAsync(() => StateHasChanged());
        }

        public void Dispose()
        {
            SpinnerService.OnShow -= ShowSpinner;
            SpinnerService.OnHide -= HideSpinner;
        }
    }
}
