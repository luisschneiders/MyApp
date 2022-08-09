using System;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.PlaygroundPage
{
    public partial class Playground : ComponentBase
    {
        private AppURL _appURL { get; }

        public Playground()
        {
            _appURL = new();
        }
    }
}
