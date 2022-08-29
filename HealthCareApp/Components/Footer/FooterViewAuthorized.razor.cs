using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Footer
{
	public partial class FooterViewAuthorized : ComponentBase
	{
		private DateTime _currentYear { get; set; }

		public FooterViewAuthorized()
		{
			_currentYear = DateTime.Now;
		}
	}
}
