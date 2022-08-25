using System;
namespace TrackingInventoryLibrary.Models
{
	public class TrackingInventorySumMopDto
	{
        public DateTime ScanTime { get; set; }

        public int CleanMopQuantity { get; set; }

        public int DirtyMopQuantity { get; set; }

        public int MopQuantity { get; set; }
    }
}
