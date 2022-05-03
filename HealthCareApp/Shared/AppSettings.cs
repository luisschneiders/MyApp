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
                case Level.Error:
                    BackgroundColor = "danger";
                    break;
                case Level.Success:
                    BackgroundColor = "success";
                    break;
            }
        }

        public void BuildSize(Size size)
        {
            switch (size)
            {
                case Size.Sm:
                    ComponentSize = "sm";
                    break;
                case Size.Md:
                    ComponentSize = "md";
                    break;
                case Size.Lg:
                    ComponentSize = "lg";
                    break;
            }
        }
    }
}
