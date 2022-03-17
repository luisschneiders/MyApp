using System;
using System.Collections.Generic;

namespace HealthCareApp.Pages.Playground
{
    public class ComponentMarkup : IComponentMarkup
    {
        public string Title { get; set; }
        public List<string> Code { get; set; }
    }
}
