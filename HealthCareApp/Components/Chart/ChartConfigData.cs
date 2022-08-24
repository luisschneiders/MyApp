using System;
namespace HealthCareApp.Components.Chart
{
	public class ChartConfigData : IChartConfigData
    {

        public string[] Labels { get; set; }
        public List<ChartConfigDataset> Datasets { get; set; }

        public ChartConfigData()
		{
            Labels = Array.Empty<string>();
            Datasets = new();
		}

    }
}
