using System;
using HealthCareApp.Components.Markup;
using HealthCareApp.Pages.PlaygroundPage;
using HealthCareApp.Shared;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.PlaygroundPage
{
	public partial class PlaygroundPageV3 : ComponentBase
	{
		private ComponentMarkup _componentMarkup { get; set; }
		private List<ComponentMarkup> _componentMarkupList { get; set; }
		private List<string> _codes { get; set; }
        private List<bool> _newLine { get; set; }
        private List<string> _cssStyle { get; set; }
        private AppURL _appURL { get; }

        public PlaygroundPageV3()
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
                new MarkupString("<div class=\"container-lg\">").ToString(),
                new MarkupString("<PageWrapper>").ToString(),
                new MarkupString("<PageTopView>").ToString(),
                new MarkupString("<PageTopWrapper>").ToString(),
                new MarkupString("<PageTopTitle />").ToString(),
                new MarkupString("<Breadcrumb AppPageLink=\"/playground/page-v3\"/>").ToString(),
                new MarkupString("</PageTopWrapper>").ToString(),
                new MarkupString("</PageTopView>").ToString(),
                new MarkupString("<PageMiddleView>").ToString(),
                new MarkupString("<PageMiddleWrapper>").ToString(),
                new MarkupString("</PageMiddleWrapper>").ToString(),
                new MarkupString("</PageMiddleView>").ToString(),
                new MarkupString("<PageBottomView>").ToString(),
                new MarkupString("<PageBottomWrapper>").ToString(),
                new MarkupString("</PageBottomWrapper>").ToString(),
                new MarkupString("</PageBottomView>").ToString(),
                new MarkupString("</PageWrapper>").ToString(),
                new MarkupString("</div>").ToString()
            };

            _cssStyle = new()
            {
                "",
                "",
                "ps-2",
                "ps-4",
                "ps-5",
                "ps-5",
                "ps-4",
                "ps-2",
                "ps-2",
                "ps-4",
                "ps-4",
                "ps-2",
                "ps-2",
                "ps-4",
                "ps-4",
                "ps-2",
                "",
                "",
                ""
            };

            _newLine = new()
            {
                true,
                true,
                false,
                false,
                false,
                false,
                false,
                true,
                false,
                false,
                false,
                true,
                false,
                false,
                false,
                true,
                true,
                false
            };

            _componentMarkup = new()
            {
                Title = "Component",
                Code = _codes,
                NewLine = _newLine,
                CssStyle = _cssStyle
            };
            _componentMarkupList.Add(_componentMarkup);

            _codes = new()
            {
                new MarkupString("<PageWrapper Styles='' />").ToString(),
                new MarkupString("<PageTopWrapper Styles='' />").ToString(),
                new MarkupString("<PageMiddleWrapper Styles='' />").ToString(),
                new MarkupString("<PageBottomWrapper Styles='' />").ToString(),
                new MarkupString("<PageTopTitle Title='' /").ToString(),
            };

            _cssStyle = new()
            {
                "",
                "",
                "",
                "",
                "",

            };

            _newLine = new()
            {
                false,
                false,
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
