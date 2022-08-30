using System;
using MyApp.Shared;
using Microsoft.AspNetCore.Components;

namespace MyApp.Pages.BarcodePage
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
