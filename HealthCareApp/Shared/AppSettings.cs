using System;
using HealthCareApp.Settings.Enum;

namespace HealthCareApp.Shared
{
    public class AppSettings
    {
        public string BackgroundColor { get; set; }

#nullable enable
        public string? Message { get; set; }

        public void BuildLevel(Level level, string? message)
        {
            switch (level)
            {
                case Level.Info:
                    BackgroundColor = "bg-info";
                    break;
                case Level.Warning:
                    BackgroundColor = "bg-warning";
                    break;
                case Level.Error:
                    BackgroundColor = "bg-danger";
                    break;
                case Level.Success:
                    BackgroundColor = "bg-success";
                    break;
            }

            Message = message;
        }
    }
}
