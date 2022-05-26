using System;
using DepartmentLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.DepartmentPage
{
	public partial class DepartmentDetails : ComponentBase
	{
        [Parameter]
        public Department? Info { get; set; }

        [Parameter]
        public bool Loading { get; set; }

        [Parameter]
        public bool HasRecord { get; set; }

        public DepartmentDetails()
        {
            Info = null;
        }
    }
}
