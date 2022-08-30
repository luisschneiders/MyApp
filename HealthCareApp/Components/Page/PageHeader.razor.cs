using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.Page
{
    public partial class PageHeader : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string Styles { get; set; }

        public PageHeader()
        {
            Styles = string.Empty;
        }
    }
}
