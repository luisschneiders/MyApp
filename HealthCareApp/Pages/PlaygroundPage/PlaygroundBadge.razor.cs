using System;
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

        public PlaygroundBadge()
        {
            _componentMarkup = new();
            _componentMarkupList = new();
            _codes = new List<string>();
            _cssStyle = new List<string>();
            _newLine = new List<bool>();
        }

        protected override void OnInitialized()
        {
            _codes = new()
            {
                new MarkupString("<Badge Level='Level.Info' Message='Info message!' />").ToString(),
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
                new MarkupString("Level='enum'").ToString(),
                new MarkupString("Message='string'").ToString()
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
                Title = "Parameter",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

        }
    }
}
