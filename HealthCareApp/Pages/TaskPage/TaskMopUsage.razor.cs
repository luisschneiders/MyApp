using System;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.TaskPage
{
    public partial class TaskMopUsage : ComponentBase
    {
        private AppURL _appURL { get; }

        public TaskMopUsage()
        {
            _appURL = new();
        }
    }
}
