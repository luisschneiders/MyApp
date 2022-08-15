using System;
namespace LabelLibrary.Models
{
	public class LabelMopDto
	{

        public Guid Id { get; set; }

        public string? Barcode { get; set; }

        public int Quantity { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime TimeOut { get; set; }

        public int ShiftType { get; set; }

        public Guid DepartmentId { get; set; }

        public string? AreaName { get; set; }

        public string? DepartmentName { get; set; }

        public bool IsActive { get; set; }

        public string? CompanyName { get; set; }

    }
}
