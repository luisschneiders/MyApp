using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.ListGroup
{
    public partial class ListGroup : ComponentBase
    {

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string Styles { get; set; }

        public ListGroup()
        {
            Styles = string.Empty;
        }
    }
}
