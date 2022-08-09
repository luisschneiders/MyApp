using HealthCareApp.Settings.Enum;
using HealthCareApp.Settings.Theme;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Modal
{
    public partial class Modal : ComponentBase
    {
        [Parameter]
        public RenderFragment? Title { get; set; }

        [Parameter]
        public RenderFragment? Body { get; set; }

        [Parameter]
        public RenderFragment? Footer { get; set; }

        [Parameter]
        public Size Size { get; set; }

        [Parameter]
        public bool IsCloseButtonVisible { get; set; }

        private ModalDisplay _modalStyleDisplay { get; set; }
        private string _modalClass { get; set; }
        private bool _showBackdrop { get; set; }
        private Guid _modalId { get; set; }

        public Modal()
        {
            Size = Size.md;
            IsCloseButtonVisible = true;
            _modalStyleDisplay = ModalDisplay.none;
            _modalClass = string.Empty;
            _showBackdrop = false;
            _modalId = Guid.Empty;
        }

        public async Task Open(Guid target)
        {
            _modalId = target;
            _modalStyleDisplay = ModalDisplay.block;
            await Task.Delay((int)Delay.ModalOpen);
            _modalClass = "show";
            _showBackdrop = true;

            StateHasChanged();
        }

        public async Task Close(Guid target)
        {
            _modalId = target;
            _modalClass = string.Empty;
            await Task.Delay((int)Delay.ModalClose);
            _modalStyleDisplay = ModalDisplay.none;
            _showBackdrop = false;

            StateHasChanged();
        }
    }
}
