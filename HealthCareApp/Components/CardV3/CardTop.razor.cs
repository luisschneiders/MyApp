using System;
using MyApp.Settings.Theme;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.CardV3
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
