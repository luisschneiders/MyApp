using System;
using HealthCareApp.Settings.Theme;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Card
{
    public partial class CardViewHeader : ComponentBase
    {
        [Parameter]
        public string ImageUrl { get; set; }

        [Parameter]
        public string Icon { get; set; }

        [Parameter]
        public Theme IconTheme { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string ImageDescription { get; set; }

        public CardViewHeader()
        {
            ImageUrl = string.Empty;
            Icon = string.Empty;
            IconTheme = Theme.App;
            Title = string.Empty;
            ImageDescription = "Image description";
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (string.IsNullOrWhiteSpace(ImageUrl) && string.IsNullOrWhiteSpace(Icon))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
