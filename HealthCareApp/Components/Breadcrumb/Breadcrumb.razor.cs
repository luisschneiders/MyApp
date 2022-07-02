using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Breadcrumb
{
	public partial class Breadcrumb : ComponentBase
	{
        [Inject]
        private NavigationManager _navigationManager { get; set; } = default!;

        [Parameter]
        public bool IsVisible { get; set; } = true;

        private string _baseUri { get; set; } = string.Empty;
        private string[] _uri { get; set; } = default!;
        private string[] _path { get; set; } = default!;

        public Breadcrumb()
		{
		}

        protected override Task OnInitializedAsync()
        {
            _baseUri = _navigationManager.BaseUri;
            _uri = _navigationManager.Uri.Split(_baseUri);
            _path = _uri[1].Split("/");

            return base.OnInitializedAsync();
        }
    }
}

