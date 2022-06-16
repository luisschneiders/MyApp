using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackingInventoryLibrary.Models
{
	public class TrackingInventoryMops : TrackingInventory
	{

		[Required]
		public DateTime TimeIn { get; set; }

		[Required]
		public DateTime TimeOut { get; set; }

		[Required]
		[Range(1, 30, ErrorMessage = "Quantity must be between 1 and 30")]
		public int CleanMopQuantity { get; set; }

		[Required]
		[Range(1, 30, ErrorMessage = "Quantity must be between 1 and 30")]
		public int DirtyMopQuantity { get; set; }

		[Required]
		[ForeignKey("LabelMop")]
		public Guid LabelMopId { get; set; }
	}
}
