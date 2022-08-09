using HealthCareApp.Components.Markup;
using HealthCareApp.Components.Modal;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.PlaygroundPage
{
	public partial class PlaygroundModal : ComponentBase
	{
        private Modal _modal { get; set; }
        private Guid _modalTarget { get; set; }

        private ComponentMarkup _componentMarkup { get; set; }
        private List<ComponentMarkup> _componentMarkupList { get; set; }
        private List<string> _codes { get; set; }
        private List<bool> _newLine { get; set; }
        private List<string> _cssStyle { get; set; }
        private AppURL _appURL { get; }

        public PlaygroundModal()
		{
            _modal = new();

            _componentMarkup = new();
            _componentMarkupList = new();
            _codes = new List<string>();
            _cssStyle = new List<string>();
            _newLine = new List<bool>();
            _appURL = new();
        }

        private async Task OpenModalAsync()
        {
            _modalTarget = Guid.NewGuid();
            await Task.FromResult(_modal.Open(_modalTarget));
        }

        private async Task CloseModalAsync()
        {
            await Task.FromResult(_modal.Close(_modalTarget));
        }

        protected override void OnInitialized()
        {
            _codes = new()
            {

                new MarkupString("<Modal @ref=\"_modal\" Size=\"Size.fullscreen\" IsCloseButtonVisible=\"true\">").ToString(),
                new MarkupString("<Title></Title>").ToString(),
                new MarkupString("<Body>").ToString(),
                new MarkupString("</Body>").ToString(),
                new MarkupString("<Footer>").ToString(),
                new MarkupString("</Footer>").ToString(),
                new MarkupString("</Modal>").ToString(),

            };

            _cssStyle = new()
            {
                "",
                "ps-2",
                "ps-2",
                "ps-2",
                "ps-2",
                "ps-2",
                ""
            };

            _newLine = new()
            {
                true,
                true,
                false,
                true,
                false,
                true,
                false,
            };

            _componentMarkup = new()
            {
                Title = "Modal",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("@ref=\"The modal instance\"").ToString(),
                new MarkupString("Size=\"enum\"").ToString(),
                new MarkupString("IsCloseButtonVisible=\"bool\"").ToString(),
            };

            _cssStyle = new()
            {
                "",
                "",
                "",
            };

            _newLine = new()
            {
                false,
                false,
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
        }
    }
}
