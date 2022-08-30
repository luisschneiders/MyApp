using System;
using MyApp.Shared;
using Microsoft.AspNetCore.Components;

namespace MyApp.Pages.TaskPage
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
