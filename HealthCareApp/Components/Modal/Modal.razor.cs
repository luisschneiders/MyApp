using System;
using System.Threading.Tasks;
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
        public Theme Theme { get; set; } = Theme.App;

        [Parameter]
        public ModalSize Size { get; set; } = ModalSize.md;

        private ModalDisplay ModalStyleDisplay { get; set; } = ModalDisplay.none;
        private string ModalClass { get; set; } = "";
        private bool ShowBackdrop { get; set; } = false;
        private Guid ModalId { get; set; } = Guid.Empty;

        public async Task Open(Guid target)
        {
            ModalId = target;
            ModalStyleDisplay = ModalDisplay.block;
            await Task.Delay((int)Delay.ModalOpen);
            ModalClass = "show";
            ShowBackdrop = true;

            StateHasChanged();
        }

        public async Task Close(Guid target)
        {
            ModalId = target;
            ModalClass = "";
            await Task.Delay((int)Delay.ModalClose);
            ModalStyleDisplay = ModalDisplay.none;
            ShowBackdrop = false;

            StateHasChanged();
        }

    }
}
