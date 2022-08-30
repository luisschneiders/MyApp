using System;
namespace MyApp.Components.Chart
{
	public class ChartConfigDataset : IChartConfigDataset
	{
        public string Label { get; set; }
        public List<string> Data { get; set; }
        public List<string> BackgroundColor { get; set; }
        public List<string> BorderColor { get; set; }
        public int BorderWidth { get; set; }

        public ChartConfigDataset()
		{
            Label = string.Empty;
            Data = new();
            BackgroundColor = new();
            BorderColor = new();
            BorderWidth = 1;
		}
	}
}
