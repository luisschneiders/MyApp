using System;
using DateTimeLibrary;
using EmployeeLibrary.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MyApp.Data;
using MyApp.Settings.Enum;
using static MyApp.Components.Chart.User.ChartUsers;

namespace MyApp.Components.Chart.User
{
	public partial class ChartUsers : ComponentBase
	{
        [Inject]
        private EmployeeService _employeeService { get; set; } = default!;

        private IJSObjectReference? _chartModule;
        private List<string> _chartBackgroundColors { get; set; }
        private List<string> _chartBorderColors { get; set; }
        private List<string> _chartLabels { get; set; }
        private List<string> _chartData { get; set; }

        private EmployeeCountDto _employeeCountDto { get; set; }

        public ChartUsers()
		{
            _chartBackgroundColors = new()
            {
                BackgroundColor.Green,
                BackgroundColor.Yellow,
            };
            _chartBorderColors = new()
            {
                BorderColor.Green,
                BorderColor.Yellow,
            };
            _chartLabels = new()
            {
                Users.Active.ToString(),
                Users.Inactive.ToString(),
            };
            _chartData = new();

            _employeeCountDto = new();

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _chartModule = await JS.InvokeAsync<IJSObjectReference>("import", "./Components/Chart/Chart.razor.js");
            }
            await Task.CompletedTask;
        }

        protected override async Task OnInitializedAsync()
        {
            await SetChartData();
            await Task.CompletedTask;
        }

        public class EmployeeCountDto
        {
            public int Active { get; set; }
            public int Inactive { get; set; }
        }

        private async Task SetChartData()
        {
            _employeeCountDto = await _employeeService.CountEmployeeAsync();

            _chartData.Add(_employeeCountDto.Active.ToString());
            _chartData.Add(_employeeCountDto.Inactive.ToString());
        }
    }
}
