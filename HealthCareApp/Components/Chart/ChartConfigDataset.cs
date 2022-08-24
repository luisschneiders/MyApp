using System;
namespace HealthCareApp.Components.Chart
{
	public class ChartConfigDataset : IChartConfigDataset
	{
        public string Label { get; set; }
        public string[] Data { get; set; } = default!;
        public string[] BackgroundColor { get; set; } = default!;
        public string[] BorderColor { get; set; } = default!;
        public int BorderWidth { get; set; }

        public ChartConfigDataset()
		{
            Label = string.Empty;
            BorderWidth = 1;
		}
	}
}
