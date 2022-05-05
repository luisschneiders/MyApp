using HealthCareApp.Components.Modal;

namespace HealthCareApp.Pages.Playground
{
	public partial class PlaygroundModal
	{
        private Modal _modalSmall { get; set; }
        private Modal _modalMedium { get; set; }
        private Modal _modalLarge { get; set; }

        private Guid _modalSmallTarget { get; set; }
        private Guid _modalMediumTarget { get; set; }
        private Guid _modalLargeTarget { get; set; }

        public PlaygroundModal()
		{
            _modalSmall = new();
            _modalMedium = new();
            _modalLarge = new();
        }

        private async Task OpenSmallModalAsync()
        {
            _modalSmallTarget = Guid.NewGuid();
            await Task.FromResult(_modalSmall.Open(_modalSmallTarget));
        }

        private async Task CloseSmallModalAsync()
        {
            await Task.FromResult(_modalSmall.Close(_modalSmallTarget));
        }

        private async Task OpenMediumModalAsync()
        {
            _modalMediumTarget = Guid.NewGuid();
            await Task.FromResult(_modalMedium.Open(_modalMediumTarget));
        }

        private async Task CloseMediumModalAsync()
        {
            await Task.FromResult(_modalMedium.Close(_modalMediumTarget));
        }

        private async Task OpenLargeModalAsync()
        {
            _modalLargeTarget = Guid.NewGuid();
            await Task.FromResult(_modalLarge.Open(_modalLargeTarget));
        }

        private async Task CloseLargeModalAsync()
        {
            await Task.FromResult(_modalLarge.Close(_modalLargeTarget));
        }
    }
}
