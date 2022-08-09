using HealthCareApp.Settings.Enum;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Badge
{
    public partial class Badge
    {

        [Parameter]
        public string BackgroundColor { get; set; }

        [Parameter]
        public string Message { get; set; }

        public Badge()
        {
            BackgroundColor = Level.Info.ToString().ToLower();
            Message = string.Empty;
        }
    }
}
