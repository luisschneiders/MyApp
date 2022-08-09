using System;
using HealthCareApp.Components.Markup;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.PlaygroundPage
{
    public partial class PlaygroundBadge : ComponentBase
    {

        private ComponentMarkup _componentMarkup { get; set; }
        private List<ComponentMarkup> _componentMarkupList { get; set; }
        private List<string> _codes { get; set; }
        private List<bool> _newLine { get; set; }
        private List<string> _cssStyle { get; set; }
        private AppURL _appURL { get; }

        public PlaygroundBadge()
        {
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
                new MarkupString("<Badge BackgroundColor=\"@Level.Info.ToString().ToLower()\" Message=\"Info message!\" />").ToString(),
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
                Title = "Badge",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("BackgroundColor=\"string\"").ToString(),
                new MarkupString("Message=\"string\"").ToString()
            };

            _cssStyle = new()
            {
                "",
                ""
            };

            _newLine = new()
            {
                false,
                false,
            };

            _componentMarkup = new()
            {
                Title = "Parameters",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

        }
    }
}
