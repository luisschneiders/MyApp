using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.CardV3
{
	public partial class CardProfile : ComponentBase
	{
        [Parameter]
		public RenderFragment? ChildContent { get; set; }

        [Parameter]
		public string CardProfileIcon { get; set; }

        [Parameter]
		public string CardProfileTitle { get; set; }

		public CardProfile()
		{
            CardProfileIcon = string.Empty;
			CardProfileTitle = string.Empty;
		}
	}
}
