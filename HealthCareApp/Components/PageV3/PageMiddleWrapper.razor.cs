using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.PageV3
{
	public partial class PageMiddleWrapper : ComponentBase
	{
        [Parameter]
		public RenderFragment? ChildContent { get; set; }

		[Parameter]
		public string Styles { get; set; }

		public PageMiddleWrapper()
        {
			Styles = string.Empty;
        }

	}
}

