using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.Page
{
    public partial class PageFooter : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string Styles { get; set; }

        public PageFooter()
        {
            Styles = string.Empty;
        }
    }
}
