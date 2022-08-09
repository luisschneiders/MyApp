using System;
using HealthCareApp.Components.Markup;
using HealthCareApp.Components.Toast;
using HealthCareApp.Settings.Enum;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.PlaygroundPage
{
    public partial class PlaygroundToast : ComponentBase
    {
        [Inject]
        private ToastService _toastService { get; set; }

        private ComponentMarkup _componentMarkup { get; set; }
        private List<ComponentMarkup> _componentMarkupList { get; set; }
        private List<string> _codes { get; set; }
        private List<bool> _newLine { get; set; }
        private List<string> _cssStyle { get; set; }
        private AppURL _appURL { get; }

        public PlaygroundToast()
        {
            _toastService = new();
            _componentMarkup = new();
            _componentMarkupList = new();
            _codes = new List<string>();
            _cssStyle = new List<string>();
            _newLine = new List<bool>();
            _appURL = new();
        }

        protected override void OnInitialized()
        {

            _codes = new()
            {
                new MarkupString("<Toast />").ToString(),
            };

            _cssStyle = new()
            {
                "",
            };

            _newLine = new()
            {
                false,
            };

            _componentMarkup = new()
            {
                Title = "Toast",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("ToastService.ShowToast('Toast message!', Level.Info)").ToString(),
            };

            _cssStyle = new()
            {
                "",
            };

            _newLine = new()
            {
                false,
            };

            _componentMarkup = new()
            {
                Title = "Service",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("ShowToast(string, enum)").ToString(),
            };

            _cssStyle = new()
            {
                "",
            };

            _newLine = new()
            {
                false,
            };

            _componentMarkup = new()
            {
                Title = "Method",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

        }

        private void ShowToast()
        {
            _toastService.ShowToast("Toast message!", Level.Info);
        }
    }
}
