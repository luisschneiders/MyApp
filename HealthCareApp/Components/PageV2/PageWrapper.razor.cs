using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageV2
{
	public partial class PageWrapper : ComponentBase
	{

        [Parameter]
        public RenderFragment? PageHeaderView { get; set; }

        [Parameter]
        public RenderFragment? PageBodyView { get; set; }

        [Parameter]
        public RenderFragment? PageFooterView { get; set; }

    }
}
