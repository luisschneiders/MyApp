using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Card
{
    public partial class CardView
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string Link { get; set; } = "";
    }
}
