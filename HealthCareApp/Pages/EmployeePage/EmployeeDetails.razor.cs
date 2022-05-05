using System;
using EmployeeLibrary.Models;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.EmployeePage
{
    public partial class EmployeeDetails : ComponentBase
    {

        [Parameter]
        public Employee? Info { get; set; }

        [Parameter]
        public bool Loading { get; set; }

        public EmployeeDetails()
        {
            Info = null;
        }

    }
}
