using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Page
{
    public partial class PageMenu
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
