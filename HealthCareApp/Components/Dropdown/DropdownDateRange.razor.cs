﻿using System;
using DateTimeLibrary;
using MyApp.Settings.Enum;
using MyApp.Settings.Theme;
using Microsoft.AspNetCore.Components;

namespace MyApp.Components.Dropdown
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

        private string _dateRangeLabel { get; set; }

        private bool _isValidDateRange { get; set; }

        public DropdownDateRange()
		{
            _isValidDateRange = true;
            _dateRangeLabel = $"No date assigned!";

            DateTimeRange = new DateTimeRange
            {
                Start = DateTime.Now,
                End = DateTime.Now
            };

            IsDisplayLargeNone = false;
            ButtonColor = Theme.light;
            IconColor = Theme.success;
            ButtonSize = Size.md;
            DropdownPosition = "dropdown";


        }

        protected override async Task OnInitializedAsync()
        {
            _dateRangeLabel = await UpdateDateRangeLabel();

            await Task.CompletedTask;
        }

        private async Task<string> UpdateDateRangeLabel()
        {
            string dateRangeDescription = string.Empty;
            if (DateTimeRange.Start.Date == DateTimeRange.End.Date)
            {
                dateRangeDescription = $"{DateTimeRange.Start.Date.ToString("dd/MM/yy")}";
            }
            else
            {
                dateRangeDescription = $"{DateTimeRange.Start.Date.ToString("dd/MM/yy")} - {DateTimeRange.End.Date.ToString("dd/MM/yy")}";
            }

            return await Task.FromResult(dateRangeDescription);
        }

        private async Task ChangeDateAsync()
        {
            DateTimeRange.CheckDate();
            if (!DateTimeRange.CheckDate())
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
