using System;
using System.Collections.Generic;
using HealthCareApp.Components.Toast;
using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.Playground
{
    public partial class PlaygroundToast : ComponentBase
    {
        [Inject]
        private ToastService ToastService { get; set; }

        private ComponentMarkup ComponentMarkup { get; set; }
        private List<ComponentMarkup> ComponentMarkupList { get; set; }
        private List<string> Codes { get; set; }

        protected override void OnInitialized()
        {

            ComponentMarkup = new();
            ComponentMarkupList = new List<ComponentMarkup>();

            Codes = new()
            {
                new MarkupString("<Toast />").ToString()
            };
            ComponentMarkup = new()
            {
                Title = "Component",
                Code = Codes
            };
            ComponentMarkupList.Add(ComponentMarkup);

            Codes = new()
            {
                new MarkupString("ToastService.ShowToast('Toast message!', Level.Info)").ToString(),
            };
            ComponentMarkup = new()
            {
                Title = "Service",
                Code = Codes
            };
            ComponentMarkupList.Add(ComponentMarkup);

            Codes = new()
            {
                new MarkupString("ShowToast(string, enum)").ToString(),
            };
            ComponentMarkup = new()
            {
                Title = "Method",
                Code = Codes
            };
            ComponentMarkupList.Add(ComponentMarkup);

        }

        private void ShowToast()
        {
            ToastService.ShowToast("Toast message!", Level.Info);
        }
    }
}
