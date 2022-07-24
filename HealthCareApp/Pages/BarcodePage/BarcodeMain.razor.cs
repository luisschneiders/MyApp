using System;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.BarcodePage
{
    public partial class BarcodeMain : ComponentBase
    {
        private AppURL _appURL { get; }

        public BarcodeMain()
        {
            _appURL = new();
        }
    }
}
