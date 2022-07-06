using System;
using HealthCareApp.Data;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.DashboardPage
{
	public partial class ActiveUsers : ComponentBase
	{
        [Inject]
        private EmployeeService _employeeService { get; set; } = default!;

        private int _activeUsers { get; set; }

        public ActiveUsers()
		{
		}

        protected async override Task OnInitializedAsync()
        {
            _activeUsers = await _employeeService.CountActiveEmployeeAsync();

            await Task.CompletedTask;
        }
    }
}
