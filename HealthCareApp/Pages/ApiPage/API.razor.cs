using System;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.ApiPage
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
