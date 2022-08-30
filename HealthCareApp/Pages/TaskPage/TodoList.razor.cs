using System;
using MyApp.Shared;
using Microsoft.AspNetCore.Components;

namespace MyApp.Pages.TaskPage
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
