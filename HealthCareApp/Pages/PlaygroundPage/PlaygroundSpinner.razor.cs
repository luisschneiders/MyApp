using HealthCareApp.Components.Spinner;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.PlaygroundPage
{
    public partial class PlaygroundSpinner
    {
        [Inject]
        private SpinnerService _spinnerService { get; set; }

        public PlaygroundSpinner()
        {
            _spinnerService = new();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await Task.Run(() => _spinnerService.ShowSpinner());
            await Task.CompletedTask;
        }
    }
}
