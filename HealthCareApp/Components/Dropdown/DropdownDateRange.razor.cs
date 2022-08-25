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
        public EventCallback OnSubmitSuccess { get; set; }

        [Parameter]
        public IDateTimeRange DateTimeRange { get; set; }

        [Parameter]
        public bool IsDisplayLargeNone { get; set; }

        [Parameter]
        public Theme IconColor { get; set; }

        [Parameter]
        public Theme ButtonColor { get; set; }

        [Parameter]
        public Size ButtonSize { get; set; }

        [Parameter]
        public string DropdownPosition { get; set; }

        private IDateTimeRange _dateTimeRange { get; set; }
        private string _dateRangeLabel { get; set; }

        private bool _isValidDateRange { get; set; }

        public DropdownDateRange()
		{
            _isValidDateRange = true;
            _dateRangeLabel = $"No date assigned!";
            _dateTimeRange = new DateTimeRange
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };

            DateTimeRange = _dateTimeRange;
            IsDisplayLargeNone = false;
            ButtonColor = Theme.light;
            IconColor = Theme.success;
            ButtonSize = Size.md;
            DropdownPosition = "dropdown";


        }

        protected override async Task OnInitializedAsync()
        {
            _dateTimeRange = DateTimeRange;
            _dateRangeLabel = await UpdateDateRangeLabel();
            await Task.CompletedTask;
        }

        private async Task<string> UpdateDateRangeLabel()
        {
            string dateRangeDescription = string.Empty;
            if (_dateTimeRange.Start.Date == _dateTimeRange.End.Date)
            {
                dateRangeDescription = $"{_dateTimeRange.Start.Date.ToString("dd/MM/yy")}";
            }
            else
            {
                dateRangeDescription = $"{_dateTimeRange.Start.Date.ToString("dd/MM/yy")} - {_dateTimeRange.End.Date.ToString("dd/MM/yy")}";
            }

            return await Task.FromResult(dateRangeDescription);
        }

        private async Task ChangeDateAsync()
        {
            _dateTimeRange.CheckDate();
            if (!_dateTimeRange.CheckDate())
            {
                _isValidDateRange = false;
            }
            else
            {
                _isValidDateRange = true;
                _dateRangeLabel = await UpdateDateRangeLabel();

                await OnSubmitSuccess.InvokeAsync();

            }
            await Task.CompletedTask;
        }
    }
}
