using System;

namespace HealthCareApp.Components.Breadcrumb
{
    public interface IBreadcrumbLink
    {
        public string AppPageURL { get; set; }
        public string AppPageURLValue { get; set; }
        public bool IsActive { get; set; }
    }
}
