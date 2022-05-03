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
        private ToastService _toastService { get; set; }

        private ComponentMarkup _componentMarkup { get; set; }
        private List<ComponentMarkup> _componentMarkupList { get; set; }
        private List<string> _codes { get; set; }

        public PlaygroundToast()
        {
            _toastService = new();
            _componentMarkup = new();
            _componentMarkupList = new();
            _codes = new List<string>();
        }

        protected override void OnInitialized()
        {

            _componentMarkup = new();
            _componentMarkupList = new List<ComponentMarkup>();

            _codes = new()
            {
                new MarkupString("<Toast />").ToString()
            };
            _componentMarkup = new()
            {
                Title = "Component",
                Code = _codes
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("ToastService.ShowToast('Toast message!', Level.Info)").ToString(),
            };
            _componentMarkup = new()
            {
                Title = "Service",
                Code = _codes
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("ShowToast(string, enum)").ToString(),
            };
            _componentMarkup = new()
            {
                Title = "Method",
                Code = _codes
            };
            _componentMarkupList.Add(_componentMarkup);

        }

        private void ShowToast()
        {
            _toastService.ShowToast("Toast message!", Level.Info);
        }
    }
}
