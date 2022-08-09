using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageV3
{
	public partial class PageBottomWrapper : ComponentBase
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		[Parameter]
		public string Styles { get; set; }

		public PageBottomWrapper()
		{
			Styles = string.Empty;
		}
	}
}

