using System;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.ListGroup
{
    public partial class ListGroupItem : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public string ItemURL { get; set; }

        [Parameter]
        public string Styles { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public string IconSize { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Summary { get; set; }

        public ListGroupItem()
        {
            ItemURL = string.Empty;
            Styles = string.Empty;
            Icon = "bi bi-chevron-right";
            IconSize = "md-icon";
            Title = "Add title";
            Summary = "Add a small summary here...";
        }
    }
}
