using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Card
{
    public partial class CardViewBody
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string Styles { get; set; }

        public CardViewBody()
        {
            Styles = string.Empty;
        }
    }
}
