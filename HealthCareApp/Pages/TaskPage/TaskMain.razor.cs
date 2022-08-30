using System;
using MyApp.Shared;
using Microsoft.AspNetCore.Components;

namespace MyApp.Pages.TaskPage
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
