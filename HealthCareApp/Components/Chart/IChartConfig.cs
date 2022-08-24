using System;
using HealthCareApp.Settings.Enum;

namespace HealthCareApp.Components.Chart
{
	public interface IChartConfig
    {
		public string Type { get; set; }
		public ChartConfigData Data { get; set; }
		public object Options { get; set; }
    }
}
