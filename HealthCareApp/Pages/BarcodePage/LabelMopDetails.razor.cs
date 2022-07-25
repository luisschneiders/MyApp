using LabelLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.BarcodePage
{
	public partial class LabelMopDetails : ComponentBase 
	{
        [Parameter]
        public LabelMopDto? Info { get; set; }

        [Parameter]
        public bool Loading { get; set; }

        public LabelMopDetails()
        {
            Info = null;
        }
    }
}
