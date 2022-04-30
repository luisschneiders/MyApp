using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Page
{
    public partial class PageWrapper
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
