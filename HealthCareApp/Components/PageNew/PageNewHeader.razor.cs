using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageNew
{
	public partial class PageNewHeader : ComponentBase
	{
        //[Parameter]
        //public RenderFragment? PageNewHeaderView { get; set; }

        [Parameter]
		public RenderFragment? PageNewHeaderTitleView { get; set; }

		[Parameter]
		public RenderFragment? PageNewHeaderMenuView { get; set; }

		public PageNewHeader()
		{
		}
	}
}

