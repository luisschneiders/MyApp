using System.Collections.Generic;
using DepartmentLibrary.Models;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
 

namespace HealthCareApp.Pages.DepartmentPage
{
    public partial class DepartmentMain : ComponentBase
    {
        [Inject]
        private DepartmentService DepartmentService { get; set; }

        [Inject]
        private SpinnerService SpinnerService { get; set; }

        private Virtualize<Department> VirtualizeContainer { get; set; }

        private Department DepartmentDetails { get; set; }

        private bool IsLoading { get; set; }

        private string SearchTerm { get; set; }

        private List<Department> Results { get; set; }
        private List<Department> Departments { get; set; }

        /*
         * Add component DepartmentModalAdd & DepartmentModalUpdate reference
         */
        private DepartmentModalAdd DepartmentModalAdd { get; set; }
        private DepartmentModalUpdate DepartmentModalUpdate { get; set; }


    }
}
