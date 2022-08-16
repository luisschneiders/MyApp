using System;
namespace TrackingInventoryLibrary.Models
{
	public class TrackingInventoryMopDto
	{
        public Guid Id { get; set; }

        public DateTime ScanTime { get; set; }

        public int EntryType { get; set; }

        public int CleanMopQuantity { get; set; }

        public int DirtyMopQuantity { get; set; }

        public string? Barcode { get; set; }

        public string? DepartmentName { get; set; }

        public string? AreaName { get; set; }

        public int ShiftType { get; set; }

        public int MopQuantity { get; set; }

        public bool IsActive { get; set; }

    }
}
