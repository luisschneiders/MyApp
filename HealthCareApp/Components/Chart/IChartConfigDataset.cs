using System;
namespace HealthCareApp.Components.Chart
{
	public interface IChartConfigDataset
	{
		public string Label { get; set; }
		public string[] Data { get; set; }
        public string[] BackgroundColor { get; set; }
        public string[] BorderColor { get; set; }
		public int BorderWidth { get; set; }
    }
}
