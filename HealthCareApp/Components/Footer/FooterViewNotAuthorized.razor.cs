using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Footer
{
	public partial class FooterViewNotAuthorized : ComponentBase
	{
        private DateTime _currentYear { get; set; }

        public FooterViewNotAuthorized()
		{
            _currentYear = DateTime.Now;
        }
	}
}
