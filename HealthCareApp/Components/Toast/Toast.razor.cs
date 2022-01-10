using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Toast
{
    public partial class Toast : ComponentBase, IDisposable
    {
        [Inject]
        ToastService ToastService { get; set; }

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

        private void ShowToast(string message, ToastLevel level)
        {
            BuildToastSettings(message, level);
            IsVisible = true;
            InvokeAsync(() => StateHasChanged());
        }

        private void HideToast()
        {
            IsVisible = false;
            InvokeAsync(() => StateHasChanged());
        }

        private void BuildToastSettings(string message, ToastLevel level)
        {
            switch (level)
            {
                case ToastLevel.Info:
                    ToastBackgroundColor = "bg-info";
                    break;
                case ToastLevel.Warning:
                    ToastBackgroundColor = "bg-warning";
                    break;
                case ToastLevel.Error:
                    ToastBackgroundColor = "bg-danger";
                    break;
                case ToastLevel.Success:
                    ToastBackgroundColor = "bg-success";
                    break;
            }

            ToastMessage = message;
        }

        public void Dispose()
        {
            ToastService.OnShow -= ShowToast;
        }

    }
}
