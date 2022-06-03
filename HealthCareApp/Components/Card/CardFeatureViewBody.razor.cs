using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Card
{
	public partial class CardFeatureViewBody : ComponentBase
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		public CardFeatureViewBody()
		{
		}
	}
}

