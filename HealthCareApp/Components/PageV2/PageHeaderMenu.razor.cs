using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageV2
{
	public partial class PageHeaderMenu : ComponentBase
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
	}
}

