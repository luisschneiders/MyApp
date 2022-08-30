using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.PageV2
{
	public partial class PageHeaderWrapper : ComponentBase
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		[Parameter]
		public string Styles { get; set; }

		public PageHeaderWrapper()
		{
			Styles = string.Empty;
		}
	}
}

