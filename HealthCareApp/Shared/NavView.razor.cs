using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Shared
{
    public partial class NavView : ComponentBase
    {
        private AppURL _appURL { get; }

        public NavView()
        {
            _appURL = new();
        }

    }
}
