using System;
using HealthCareApp.Settings.Enum;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Toast
{
    public partial class Toast : ComponentBase, IDisposable
    {
        [Inject]
        ToastService ToastService { get; set; }

        AppSettings AppSettings { get; set; } = new();

        protected Guid ToastId { get; set; } = Guid.NewGuid();
        protected string ToastMessage { get; set; }
        protected bool IsVisible { get; set; }
        protected string ToastBackgroundColor { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();

            ToastService.OnShow += ShowToast;
            ToastService.OnHide += HideToast;
        }

        private void ShowToast(string message, Level level)
        {

            AppSettings.BuildLevel(level);

            ToastBackgroundColor = AppSettings.BackgroundColor;
            ToastMessage = message;

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
