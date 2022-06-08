using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageNew
{
	public partial class PageNewWrapper : ComponentBase
	{

        [Parameter]
        public RenderFragment? PageNewHeaderView { get; set; }

        [Parameter]
        public RenderFragment? PageNewBodyView { get; set; }

	}
}
