using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Card
{
    public partial class CardWrapper
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
