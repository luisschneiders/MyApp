using System;
using HealthCareApp.Settings.Enum;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Spinner
{
    public partial class Spinner
    {
        [Parameter]
        public Size Size { get; set; }

        private AppSettings AppSettings { get; set; } = new();

        private string ComponentSize { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AppSettings.BuildSize(Size);
            ComponentSize = AppSettings.ComponentSize;
        }
    }
}
