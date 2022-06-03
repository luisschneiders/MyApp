using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Card
{
	public partial class CardFeatureWrapper : ComponentBase
	{
		[Parameter]
		public RenderFragment? ChildContent { get; set; }
	}
}
