using System;
using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.LabelPage
{
	public partial class LabelMopDetails : ComponentBase 
	{
        [Parameter]
        public LabelMop? Info { get; set; }

        [Parameter]
        public bool Loading { get; set; }

        public LabelMopDetails()
        {
            Info = null;
        }
    }
}

