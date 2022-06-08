using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageNew
{
	public partial class PageNewBody : ComponentBase
	{
        [Parameter]
		public RenderFragment? PageNewBodyView { get; set; }

		public PageNewBody()
		{
		}
	}
}

