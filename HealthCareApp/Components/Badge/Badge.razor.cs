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
        public string Message { get; set; }

        AppSettings AppSettings { get; set; } = new();

        protected string BackgroundColor { get; set; }

        protected override void OnInitialized()
        {
            AppSettings.BuildLevel(Level, Message);
            BackgroundColor = AppSettings.BackgroundColor;
            Message = AppSettings.Message;

            base.OnInitialized();
        }

    }
}
