using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.Page
{
    public partial class PageMenu
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
