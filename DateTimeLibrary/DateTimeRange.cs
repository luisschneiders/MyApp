using System;
namespace DateTimeLibrary
{
	public class DateTimeRange : IDateTimeRange
	{
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public DateTimeRange()
		{
		}
	}
}
