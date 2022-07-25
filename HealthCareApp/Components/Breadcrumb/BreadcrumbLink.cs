using System;
using System.Text;

namespace HealthCareApp.Components.Breadcrumb
{
    public class BreadcrumbLink : IBreadcrumbLink
    {
        public string AppPageURL { get; set; }
        public string AppPageURLValue { get; set; }
        public bool IsActive { get; set; }

        public BreadcrumbLink()
        {
            AppPageURL = string.Empty;
            AppPageURLValue = string.Empty;
            IsActive = false;
        }
    }
}
