using System;
namespace HealthCareApp.Components.Chart
{
	public interface IChartConfigData
    {
		public string[] Labels { get; set; }
		public List<ChartConfigDataset> Datasets { get; set; }
    }
}
