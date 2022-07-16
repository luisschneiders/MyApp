using System;
using HealthCareApp.Settings.Enum;

namespace HealthCareApp.Shared
{
    public class AppSettings
    {
        public string BackgroundColor { get; set; }
        public string ComponentSize { get; set; }

        public AppSettings()
        {
            BackgroundColor = string.Empty;
            ComponentSize = string.Empty;
        }

        public void BuildLevel(Level level)
        {
            switch (level)
            {
                case Level.Info:
                    BackgroundColor = "info";
                    break;
                case Level.Warning:
                    BackgroundColor = "warning";
                    break;
                case Level.Danger:
                    BackgroundColor = "danger";
                    break;
                case Level.Success:
                    BackgroundColor = "success";
                    break;
                case Level.White:
                    BackgroundColor = "white";
                    break;
            }
        }

        public void BuildSize(Size size)
        {
            switch (size)
            {
                case Size.sm:
                    ComponentSize = "sm";
                    break;
                case Size.md:
                    ComponentSize = "md";
                    break;
                case Size.lg:
                    ComponentSize = "lg";
                    break;
            }
        }
    }
}
