﻿using System;
using Microsoft.AspNetCore.Components;

namespace HealthCareApp.Components.Page
{
    public partial class PageFooter
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Styles { get; set; }
    }
}