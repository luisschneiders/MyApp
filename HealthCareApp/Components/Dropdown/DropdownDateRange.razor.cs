using System;
using DateTimeLibrary;
using HealthCareApp.Settings.Enum;
using HealthCareApp.Settings.Theme;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Dropdown
{
	public partial class DropdownDateRange : ComponentBase
	{
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public bool IsDisplayLargeNone { get; set; }

        [Parameter]
        public Theme IconColor { get; set; }

        [Parameter]
        public Theme ButtonColor { get; set; }

        [Parameter]
        public Size ButtonSize { get; set; }

        [Parameter]
        public string DateRange { get; set; }

        [Parameter]
        public string DropdownPosition { get; set; }

        private IDateTimeRange _dateTimeRange { get; set; }

        public DropdownDateRange()
		{
            IsDisplayLargeNone = false;
            ButtonColor = Theme.light;
            IconColor = Theme.success;
            ButtonSize = Size.md;
            DropdownPosition = "dropdown";
            _dateTimeRange = new DateTimeRange
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };
            DateRange = $"{_dateTimeRange.Start.Date.ToString("dd/MM/yy")} - {_dateTimeRange.End.Date.ToString("dd/MM/yy")}";
        }
	}
}
