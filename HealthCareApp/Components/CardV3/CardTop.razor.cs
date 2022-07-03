using System;
using HealthCareApp.Settings.Theme;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.CardV3
{
    public partial class CardTop : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }


        public CardTop()
        {
        }

    }
}
