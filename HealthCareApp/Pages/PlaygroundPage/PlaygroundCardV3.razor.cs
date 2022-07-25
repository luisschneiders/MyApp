using System;
using HealthCareApp.Components.Markup;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.PlaygroundPage
{
	public partial class PlaygroundCardV3 : ComponentBase
	{
        private ComponentMarkup _componentMarkup { get; set; }
        private List<ComponentMarkup> _componentMarkupList { get; set; }
        private List<string> _codes { get; set; }
        private List<bool> _newLine { get; set; }
        private List<string> _cssStyle { get; set; }
        private AppURL _appURL { get; }


        public PlaygroundCardV3()
        {
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

                new MarkupString("<CardView>").ToString(),
                new MarkupString("<CardTop>").ToString(),
                new MarkupString("</CardTop>").ToString(),
                new MarkupString("<CardMiddle>").ToString(),
                new MarkupString("</CardMiddle>").ToString(),
                new MarkupString("<CardBottom>").ToString(),
                new MarkupString("</CardBottom>").ToString(),
                new MarkupString("</CardView>").ToString(),

            };

            _cssStyle = new()
            {
                "",
                "ps-2",
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
                false,
                true,
                false,
                true,
                false,
                true,
                true,
            };

            _componentMarkup = new()
            {
                Title = "Card",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("<CardView Link='' />").ToString(),
                new MarkupString("<CardMiddle Styles='' />").ToString(),
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
                Title = "Parameters",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);
        }
    }
}
