using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageV3
{
	public partial class PageTopWrapper : ComponentBase
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		[Parameter]
		public string Styles { get; set; }

		public PageTopWrapper()
		{
			Styles = string.Empty;
		}
	}
}

