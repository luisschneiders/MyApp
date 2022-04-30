using System;
using HealthCareApp.Settings.Theme;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Page
{
    public partial class PageTitle
    {         
        [Parameter]
        public string Title { get; set; } = "";

        [Parameter]
        public Theme Theme { get; set; } = Theme.App;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (string.IsNullOrWhiteSpace(Title))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
