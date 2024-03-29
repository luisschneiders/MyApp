﻿using System;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace MyApp.Pages.BarcodePage
{
	public partial class ComponentBarcodeDetails : ComponentBase
	{
        [Parameter]
		public LabelMopDto Model { get; set; }

        [Parameter]
		public string FieldsetStyle { get; set; }

        [Parameter]
		public string Icon { get; set; }

		public ComponentBarcodeDetails()
		{
			Model = new();
			FieldsetStyle = string.Empty;
			Icon = string.Empty;
		}
	}
}
