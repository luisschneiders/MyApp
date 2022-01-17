using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Message
{
    public partial class MessageView
    {
        [Parameter]
        public string Icon { get; set; } = "";

        [Parameter]
        public string Title { get; set; } = "";

        [Parameter]
        public string Message { get; set; } = "";

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
