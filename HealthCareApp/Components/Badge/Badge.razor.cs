using System;
using HealthCareApp.Settings.Enum;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Badge
{
    public partial class Badge
    {

        [Parameter]
        public Level Level { get; set; }

        [Parameter]
        public string? Message { get; set; }

        AppSettings AppSettings { get; set; } = new();

        private string? BackgroundColor { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AppSettings.BuildLevel(Level);
            BackgroundColor = AppSettings.BackgroundColor;
        }
    }
}
