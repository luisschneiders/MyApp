using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageV3
{
	public partial class PageWrapper : ComponentBase
	{

        [Parameter]
        public RenderFragment? PageTopView { get; set; }

        [Parameter]
        public RenderFragment? PageMiddleView { get; set; }

        [Parameter]
        public RenderFragment? PageBottomView { get; set; }

        [Parameter]
        public string Styles { get; set; }

        public PageWrapper()
        {
            Styles = string.Empty;
        }

    }
}
