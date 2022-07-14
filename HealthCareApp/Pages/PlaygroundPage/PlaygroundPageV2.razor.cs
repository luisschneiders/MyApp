using System;
using HealthCareApp.Components.Markup;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Pages.PlaygroundPage
{
	public partial class PlaygroundPageV2 : ComponentBase
	{
		private ComponentMarkup _componentMarkup { get; set; }
		private List<ComponentMarkup> _componentMarkupList { get; set; }
		private List<string> _codes { get; set; }
        private List<bool> _newLine { get; set; }
        private List<string> _cssStyle { get; set; }

        public PlaygroundPageV2()
		{
			_componentMarkup = new();
			_componentMarkupList = new();
			_codes = new List<string>();
            _cssStyle = new List<string>();
            _newLine = new List<bool>();
        }

        protected override void OnInitialized()
        {
            _codes = new()
            {
                new MarkupString("<PageWrapper>").ToString(),
                new MarkupString("<PageHeaderView>").ToString(),
                new MarkupString("<PageHeaderWrapper>").ToString(),
                new MarkupString("<PageHeaderTitle />").ToString(),
                new MarkupString("<PageHeaderMenu>").ToString(),
                new MarkupString("</PageHeaderMenu>").ToString(),
                new MarkupString("</PageHeaderWrapper>").ToString(),
                new MarkupString("</PageHeaderView>").ToString(),
                new MarkupString("<PageBodyView>").ToString(),
                new MarkupString("<PageBodyWrapper>").ToString(),
                new MarkupString("</PageBodyWrapper>").ToString(),
                new MarkupString("</PageBodyView>").ToString(),
                new MarkupString("<PageFooterView>").ToString(),
                new MarkupString("<PageFooterWrapper>").ToString(),
                new MarkupString("</PageFooterWrapper>").ToString(),
                new MarkupString("</PageFooterView>").ToString(),
                new MarkupString("</PageWrapper>").ToString(),
            };

            _cssStyle = new()
            {
                "",
                "ps-2",
                "ps-4",
                "ps-5",
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
                ""
            };

            _newLine = new()
            {
                true,
                false,
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
                new MarkupString("<PageHeaderWrapper Styles='' />").ToString(),
                new MarkupString("<PageBodyWrapper Styles='' />").ToString(),
                new MarkupString("<PageFooterWrapper Styles='' />").ToString(),
                new MarkupString("<PageHeaderTitle ").ToString(),
                new MarkupString("                 ParentLink='' ").ToString(),
                new MarkupString("                 ParentTitle='' ").ToString(),
                new MarkupString("                 Title='' ").ToString(),
                new MarkupString("                 IsVisible='' />").ToString(),
            };

            _cssStyle = new()
            {
                "",
                "",
                "",
                "",
                "",
                "ps-5",
                "ps-5",
                "ps-5",
                "ps-5",

            };

            _newLine = new()
            {
                false,
                false,
                false,
                false,
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
