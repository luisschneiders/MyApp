namespace HealthCareApp.Components.Markup
{
    public class ComponentMarkup : IComponentMarkup
    {
        public string Title { get; set; }
        public List<bool> NewLine { get; set; }
        public List<string>? CssStyle { get; set; }
        public List<string> Code { get; set; }

        public ComponentMarkup()
        {
            Title = string.Empty;
            Code = new List<string>();
            NewLine = new List<bool>();
        }
    }
}
