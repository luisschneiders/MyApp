using HealthCareApp.Components.Markup;
using HealthCareApp.Components.Spinner;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.PlaygroundPage
{
    public partial class PlaygroundSpinner
    {
        [Inject]
        private SpinnerService _spinnerService { get; set; }

        private ComponentMarkup _componentMarkup { get; set; }
        private List<ComponentMarkup> _componentMarkupList { get; set; }
        private List<string> _codes { get; set; }
        private List<bool> _newLine { get; set; }
        private List<string> _cssStyle { get; set; }
        private AppURL _appURL { get; }

        public PlaygroundSpinner()
        {
            _spinnerService = new();
            _componentMarkup = new();
            _componentMarkupList = new();
            _codes = new List<string>();
            _cssStyle = new List<string>();
            _newLine = new List<bool>();
            _appURL = new();
        }

        protected override void OnInitialized()
        {

            _codes = new()
            {
                new MarkupString("<Spinner />").ToString(),
            };

            _cssStyle = new()
            {
                "",
            };

            _newLine = new()
            {
                false,
            };

            _componentMarkup = new()
            {
                Title = "Spinner",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("Size='' ").ToString(),
            };

            _cssStyle = new()
            {
                "",
            };

            _newLine = new()
            {
                false,
            };

            _componentMarkup = new()
            {
                Title = "Parameters",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("SpinnerService.ShowSpinner();").ToString(),
                new MarkupString("SpinnerService.HideSpinner();").ToString(),
            };

            _cssStyle = new()
            {
                "",
                "",
            };

            _newLine = new()
            {
                false,
                false,
            };

            _componentMarkup = new()
            {
                Title = "Service",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("ShowSpinner()").ToString(),
                new MarkupString("HideSpinner()").ToString(),
            };

            _cssStyle = new()
            {
                "",
                "",
            };

            _newLine = new()
            {
                false,
                false,
            };

            _componentMarkup = new()
            {
                Title = "Method",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await Task.Run(() => _spinnerService.ShowSpinner());
            await Task.CompletedTask;
        }
    }
}
