﻿using HealthCareApp.Components.Markup;
using HealthCareApp.Components.Modal;
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

        public PlaygroundModal()
		{
            _modal = new();

            _componentMarkup = new();
            _componentMarkupList = new();
            _codes = new List<string>();
            _cssStyle = new List<string>();
            _newLine = new List<bool>();
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

                new MarkupString("<Modal>").ToString(),
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
                new MarkupString("<Modal @ref='' Size='' >").ToString(),
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
        }
    }
}
