using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.Page
{
    public partial class PageWrapper
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
