using System;
using HealthCareApp.Components.Toast;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.Playground
{
    public partial class PlaygroundToast : ComponentBase
    {
        [Inject]
        private ToastService ToastService { get; set; }

        private string MarkupStringComponent { get; set; }
        private string MarkupStringService { get; set; }
        private string MarkupStringMethod { get; set; }

        protected override void OnInitialized()
        {
            var component = "<Toast />";
            var service = "ToastService.ShowToast('Toast message!', Level.Info)";
            var method = "ShowToast(string, enum)";

            MarkupStringComponent = new MarkupString(component).ToString();
            MarkupStringService = new MarkupString(service).ToString();
            MarkupStringMethod = new MarkupString(method).ToString();
        }

        private void ShowToast()
        {
            ToastService.ShowToast("Toast message!", Level.Info);
        }
    }
}
