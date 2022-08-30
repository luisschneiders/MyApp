using System;
using MyApp.Settings.Enum;

namespace MyApp.Shared
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
                case Level.Secondary:
                    BackgroundColor = "secondary";
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
