using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Card
{
	public partial class CardFeatureViewFooter : ComponentBase
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }

		public CardFeatureViewFooter()
		{
		}
	}
}
