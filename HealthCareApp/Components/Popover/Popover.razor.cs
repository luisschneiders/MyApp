using HealthCareApp.Settings.Enum;
using HealthCareApp.Settings.Theme;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HealthCareApp.Components.Popover
{
	public partial class Popover : ComponentBase
	{
        [Parameter]
        public Position Position { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Content { get; set; }

        [Parameter]
        public Theme TextColor { get; set; }

        private IJSObjectReference? _module;

        public Popover()
		{
            Position = Position.top;
            Title = string.Empty;
            Content = string.Empty;
            TextColor = Theme.info;
		}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _module = await JS.InvokeAsync<IJSObjectReference>("import",
                    "./Components/Popover/Popover.razor.js");
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
