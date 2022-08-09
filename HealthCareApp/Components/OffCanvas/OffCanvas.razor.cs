using Microsoft.AspNetCore.Components;
using HealthCareApp.Settings.Enum;

namespace HealthCareApp.Components.OffCanvas
{
	public partial class OffCanvas : ComponentBase
	{

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        // start or end
        [Parameter]
		public string Position { get; set; }

        [Parameter]
        public OffCanvasSize Size { get; set; }

        private Guid _offCanvasId { get; set; }
        private string _offCanvasClass { get; set; }
        private bool _showBackdrop { get; set; }

        public OffCanvas()
		{
            Position = "end";
            _showBackdrop = false;
            _offCanvasId = Guid.Empty;
        }

        public async Task Open(Guid target)
        {

            _offCanvasId = target;
            await Task.Delay((int)Delay.OffCanvasOpen);
            _offCanvasClass = "show";
            _showBackdrop = true;

            StateHasChanged();
        }

        public async Task Close(Guid target)
        {
            _offCanvasId = target;
            _offCanvasClass = string.Empty;
            await Task.Delay((int)Delay.OffCanvasClose);
            _showBackdrop = false;

            StateHasChanged();
        }
    }
}
