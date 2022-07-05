using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.OffCanvas
{
	public partial class OffCanvas : ComponentBase
	{

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        // start or end
        [Parameter]
		public string Position { get; set; } = default!;

        // offcanvasLeft
        [Parameter]
        public string Id { get; set; } = default!;

        // offcanvasLeftLabel
        [Parameter]
        public string LabelId { get; set; } = default!;

        // sm, md, lg
        [Parameter]
        public string Size { get; set; } = default!;

        public OffCanvas()
		{
            Position = "end";
            Id = "offcanvasRight";
            LabelId = "offcanvasRightLabel";
        }
	}
}
