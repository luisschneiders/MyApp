using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageNew
{
	public partial class PageHeaderTitle : ComponentBase
	{

        [Parameter]
        public string ParentLink { get; set; }

        [Parameter]
        public string ParentTitle { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public bool IsVisible { get; set; }

        public PageHeaderTitle()
		{
            ParentLink = "/";
            ParentTitle = string.Empty;
            Title = string.Empty;
            IsVisible = true;
        }
    }
}

