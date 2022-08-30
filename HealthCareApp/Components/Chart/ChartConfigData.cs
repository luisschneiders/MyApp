using System;
namespace MyApp.Components.Chart
{
	public class ChartConfigData : IChartConfigData
    {

        public List<string> Labels { get; set; }
        public List<ChartConfigDataset> Datasets { get; set; }

        public ChartConfigData()
		{
            Labels = new();
            Datasets = new();
		}

    }
}
