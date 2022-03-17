using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.Playground
{
    public partial class PlaygroundBadge : ComponentBase
    {

        private ComponentMarkup ComponentMarkup { get; set; }
        private List<ComponentMarkup> ComponentMarkupList { get; set; }
        private List<string> Codes { get; set; }

        protected override void OnInitialized()
        {

            ComponentMarkup = new();
            ComponentMarkupList = new List<ComponentMarkup>();

            Codes = new()
            {
                new MarkupString("<Badge Level='Level.Info' Message='Info message!' />").ToString()
            };
            ComponentMarkup = new()
            {
                Title = "Component",
                Code = Codes
            };
            ComponentMarkupList.Add(ComponentMarkup);

            Codes = new()
            {
                new MarkupString("Level='enum'").ToString(),
                new MarkupString("Message='string'").ToString()
            };
            ComponentMarkup = new()
            {
                Title = "Parameter",
                Code = Codes
            };
            ComponentMarkupList.Add(ComponentMarkup);

        }

    }
}
