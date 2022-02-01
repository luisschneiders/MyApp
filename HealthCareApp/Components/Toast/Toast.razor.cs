using System;
using HealthCareApp.Settings.Enum;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Toast
{
    public partial class Toast : ComponentBase, IDisposable
    {
        [Inject]
        private ToastService ToastService { get; set; }

        private AppSettings AppSettings { get; set; } = new();

        private Guid ToastId { get; set; } = Guid.NewGuid();
        private string Message { get; set; }
        private bool IsVisible { get; set; }
        private string BackgroundColor { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            ToastService.OnShow += ShowToast;
            ToastService.OnHide += HideToast;
        }

        private void ShowToast(string message, Level level)
        {

            AppSettings.BuildLevel(level);

            BackgroundColor = AppSettings.BackgroundColor;
            Message = message;

            IsVisible = true;
            InvokeAsync(() => StateHasChanged());
        }

        private void HideToast()
        {
            IsVisible = false;
            InvokeAsync(() => StateHasChanged());
        }

        public void Dispose()
        {
            ToastService.OnShow -= ShowToast;
        }

    }
}
