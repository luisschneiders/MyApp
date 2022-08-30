using System;
using MyApp.Shared;
using Microsoft.AspNetCore.Components;

namespace MyApp.Pages.ApiPage
{
    public partial class API : ComponentBase
    {
        private AppURL _appURL { get; }

        public API()
        {
            _appURL = new();
        }
    }
}
