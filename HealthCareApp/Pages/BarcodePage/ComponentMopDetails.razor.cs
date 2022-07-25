using System;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.BarcodePage
{
	public partial class ComponentMopDetails : ComponentBase
	{
        [Parameter]
		public LabelMopDto Model { get; set; }

        [Parameter]
		public string FieldsetStyle { get; set; }

        [Parameter]
		public string Icon { get; set; }


		public ComponentMopDetails()
		{
			Model = new();
			FieldsetStyle = string.Empty;
			Icon = string.Empty;
		}
	}
}
