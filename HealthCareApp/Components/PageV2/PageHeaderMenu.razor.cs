using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.PageV2
{
	public partial class PageHeaderMenu : ComponentBase
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
	}
}

