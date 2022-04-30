using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Card
{
    public partial class CardViewFooter
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
