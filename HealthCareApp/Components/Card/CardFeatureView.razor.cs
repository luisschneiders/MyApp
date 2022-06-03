using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Card
{
	public partial class CardFeatureView : ComponentBase
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		[Parameter]
		public string BackgroundImage { get; set; }

		public CardFeatureView()
        {
			BackgroundImage = String.Empty;
        }
	}
}
