﻿using System;
using MyApp.Settings.Theme;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.CardV3
{
	public partial class CardProfile : ComponentBase
	{
        [Parameter]
		public RenderFragment? ChildContent { get; set; }

        [Parameter]
		public string CardProfileIcon { get; set; }

        [Parameter]
		public Theme CardProfileIconColor { get; set; }

        [Parameter]
		public string CardProfileTitle { get; set; }

		public CardProfile()
		{
            CardProfileIcon = string.Empty;
            CardProfileTitle = string.Empty;
			CardProfileIconColor = Theme.info;
		}
	}
}
