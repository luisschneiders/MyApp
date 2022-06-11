using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.PlaygroundPage
{
    public partial class PlaygroundBadge : ComponentBase
    {

        private ComponentMarkup _componentMarkup { get; set; }
        private List<ComponentMarkup> _componentMarkupList { get; set; }
        private List<string> _codes { get; set; }

        public PlaygroundBadge()
        {
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
                new MarkupString("<Badge Level='Level.Info' Message='Info message!' />").ToString()
            };
            _componentMarkup = new()
            {
                Title = "Component",
                Code = _codes
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("Level='enum'").ToString(),
                new MarkupString("Message='string'").ToString()
            };
            _componentMarkup = new()
            {
                Title = "Parameter",
                Code = _codes
            };
            _componentMarkupList.Add(_componentMarkup);

        }

    }
}
