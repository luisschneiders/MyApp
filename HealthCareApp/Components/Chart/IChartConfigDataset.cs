using System;
namespace HealthCareApp.Components.Chart
{
	public interface IChartConfigDataset
	{
		public string Label { get; set; }
		public string[] Data { get; set; }
        public List<string> BackgroundColor { get; set; }
        public List<string> BorderColor { get; set; }
		public int BorderWidth { get; set; }
    }
}
