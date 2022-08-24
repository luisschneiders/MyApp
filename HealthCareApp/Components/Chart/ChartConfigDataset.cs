using System;
namespace HealthCareApp.Components.Chart
{
	public class ChartConfigDataset : IChartConfigDataset
	{
        public string Label { get; set; }
        public string[] Data { get; set; }
        public string[] BackgroundColor { get; set; }
        public string[] BorderColor { get; set; }
        public int BorderWidth { get; set; }

        public ChartConfigDataset()
		{
            Label = string.Empty;
            Data = Array.Empty<string>();
            BackgroundColor = Array.Empty<string>();
            BorderColor = Array.Empty<string>();
            BorderWidth = 1;
		}
	}
}
