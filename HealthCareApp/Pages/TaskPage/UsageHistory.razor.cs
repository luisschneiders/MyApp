using System;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.TaskPage
{
    public partial class UsageHistory : ComponentBase
    {
        private AppURL _appURL { get; }

        public UsageHistory()
        {
            _appURL = new();
        }
    }
}
