using System;
using HealthCareApp.Settings.Theme;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Page
{
    public partial class PageHeaderTitle : ComponentBase
    {         
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public Theme Theme { get; set; }

        [Parameter]
        public bool IsVisible { get; set; }

        public PageHeaderTitle()
        {
            Title = string.Empty;
            Theme = Theme.App;
            IsVisible = true;
        }

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
