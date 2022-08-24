using System;
using HealthCareApp.Settings.Enum;

namespace HealthCareApp.Components.Chart
{
	public class ChartConfig : IChartConfig
    {

        public string Type { get; set; }
        public ChartConfigData Data { get; set; }
        public object Options { get; set; }

        public ChartConfig()
		{
            Type = ChartType.Bar.ToString().ToLower();
            Data = new();
            Options = new();
		}
    }
}
