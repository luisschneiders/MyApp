using System;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.TaskPage
{
    public partial class TodoList : ComponentBase
    {
        private AppURL _appURL { get; }

        public TodoList()
        {
            _appURL = new();
        }
    }
}
