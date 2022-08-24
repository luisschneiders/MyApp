using System;
namespace HealthCareApp.Components.Chart
{
	public interface IChartConfigData
    {
		public List<string> Labels { get; set; }
		public List<ChartConfigDataset> Datasets { get; set; }
    }
}
