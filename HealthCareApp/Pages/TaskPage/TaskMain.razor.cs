using System;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.TaskPage
{
    public partial class TaskMain : ComponentBase
    {
        private AppURL _appURL { get; }

        public TaskMain()
        {
            _appURL = new();
        }
    }
}
