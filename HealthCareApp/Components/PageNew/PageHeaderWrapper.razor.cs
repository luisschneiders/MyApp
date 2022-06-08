using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageNew
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

