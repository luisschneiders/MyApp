using System;
namespace MyApp.Components.Chart
{
	public interface IChartConfigDataset
	{
		public string Label { get; set; }
		public List<string> Data { get; set; }
        public List<string> BackgroundColor { get; set; }
        public List<string> BorderColor { get; set; }
		public int BorderWidth { get; set; }
    }
}
