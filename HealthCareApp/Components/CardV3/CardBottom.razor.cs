using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.CardV3
{
    public partial class CardBottom : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
