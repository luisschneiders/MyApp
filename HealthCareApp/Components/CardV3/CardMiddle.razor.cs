using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.CardV3
{
    public partial class CardMiddle
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string Styles { get; set; }

        public CardMiddle()
        {
            Styles = string.Empty;
        }
    }
}
