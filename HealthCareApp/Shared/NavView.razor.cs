using System;
using Microsoft.AspNetCore.Components;

namespace MyApp.Shared
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
