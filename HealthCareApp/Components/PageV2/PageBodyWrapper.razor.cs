using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.PageV2
{
	public partial class PageBodyWrapper : ComponentBase
	{
        [Parameter]
		public RenderFragment? ChildContent { get; set; }

		[Parameter]
		public string Styles { get; set; }

		public PageBodyWrapper()
        {
			Styles = string.Empty;
        }

	}
}

