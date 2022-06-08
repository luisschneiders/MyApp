using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageNew
{
	public partial class PageHeaderMenu : ComponentBase
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
	}
}

