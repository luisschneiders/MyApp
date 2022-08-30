using System;
using MyApp.Settings.Enum;

namespace MyApp.Components.Chart
{
	public interface IChartConfig
    {
		public string Type { get; set; }
		public ChartConfigData Data { get; set; }
		public object Options { get; set; }
    }
}
