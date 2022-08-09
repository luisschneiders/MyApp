using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.PageV3
{
	public partial class PageTopTitle : ComponentBase
	{

        [Parameter]
        public string Title { get; set; } = string.Empty;

        public PageTopTitle()
		{
        }
    }
}
