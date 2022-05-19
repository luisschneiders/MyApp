using AreaLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.AreaPage
{
	public partial class AreaDetails : ComponentBase
	{
		[Parameter]
		public AreaDto? Info { get; set; }

		[Parameter]
		public bool Loading { get; set; }

		public AreaDetails()
		{
			Info = null;
		}
	}
}
