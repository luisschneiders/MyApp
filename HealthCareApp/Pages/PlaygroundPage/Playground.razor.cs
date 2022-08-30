using System;
using MyApp.Shared;
using Microsoft.AspNetCore.Components;

namespace MyApp.Pages.PlaygroundPage
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
