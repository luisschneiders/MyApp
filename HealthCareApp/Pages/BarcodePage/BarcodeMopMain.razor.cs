using System;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.BarcodePage
{
    public partial class BarcodeMopMain : ComponentBase
    {
        private AppURL _appURL { get; }

        public BarcodeMopMain()
        {
            _appURL = new();
        }
    }
}
