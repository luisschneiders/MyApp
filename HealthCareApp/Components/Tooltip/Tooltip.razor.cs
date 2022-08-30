using System;
using MyApp.Settings.Enum;
using MyApp.Settings.Theme;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MyApp.Components.Tooltip
{
	public partial class Tooltip : ComponentBase
	{
        [Parameter]
		public Position Position { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
		public Theme BackgroundColor { get; set; }

        private IJSObjectReference? _module;

        public Tooltip()
		{
			Position = Position.top;
			BackgroundColor = Theme.light;
			Title = string.Empty;
		}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _module = await JS.InvokeAsync<IJSObjectReference>("import",
                    "./Components/Tooltip/Tooltip.razor.js");
            }
            await Task.CompletedTask;

        }

        /*
         * async dispose module
         */
        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            if (_module is not null)
            {
                await _module.DisposeAsync();
            }
        }
    }
}
