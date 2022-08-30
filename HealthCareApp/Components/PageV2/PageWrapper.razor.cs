using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.PageV2
{
	public partial class PageWrapper : ComponentBase
	{

        [Parameter]
        public RenderFragment? PageHeaderView { get; set; }

        [Parameter]
        public RenderFragment? PageBodyView { get; set; }

        [Parameter]
        public RenderFragment? PageFooterView { get; set; }

        [Parameter]
        public string Styles { get; set; }

        public PageWrapper()
        {
            Styles = string.Empty;
        }

    }
}
