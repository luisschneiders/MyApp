using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Card
{
	public partial class CardFeatureViewHeader : ComponentBase
	{
        [Parameter]
		public string Title { get; set; }

		public CardFeatureViewHeader()
		{
			Title = string.Empty;
		}
	}
}
