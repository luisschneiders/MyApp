using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageNew
{
	public partial class PageNewHeaderTitle : ComponentBase
	{

		[Parameter]
		public RenderFragment? PageNewHeaderTitleView { get; set; }

		public PageNewHeaderTitle()
		{
		}
	}
}

