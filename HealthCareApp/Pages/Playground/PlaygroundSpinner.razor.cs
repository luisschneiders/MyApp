using System;
using System.Threading.Tasks;
using HealthCareApp.Components.Spinner;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.Playground
{
    public partial class PlaygroundSpinner
    {
        [Inject]
        SpinnerService SpinnerService { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await Task.Run(() => SpinnerService.ShowSpinner());
        }
    }
}
