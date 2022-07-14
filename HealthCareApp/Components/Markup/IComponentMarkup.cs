namespace HealthCareApp.Components.Markup
{
    public interface IComponentMarkup
    {
        public string Title { get; set; }
        public List<bool> NewLine { get; set; }
        public List<string>? CssStyle { get; set; }
        public List<string> Code { get; set; }
    }
}
