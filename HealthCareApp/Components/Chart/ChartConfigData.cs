using System;
namespace HealthCareApp.Components.Chart
{
	public class ChartConfigData : IChartConfigData
    {

        public string[] Labels { get; set; } = default!;
        public List<ChartConfigDataset> Datasets { get; set; }

        public ChartConfigData()
		{
            Datasets = new();
		}

    }
}
