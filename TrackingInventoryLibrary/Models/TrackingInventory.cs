using System;
using System.ComponentModel.DataAnnotations;
using BaseLibrary.Models;

namespace TrackingInventoryLibrary.Models
{
	public class TrackingInventory : Base
	{
		[Key]
		public Guid Id { get; set; }

		[Required]
		public string Barcode { get; set; } = default!;

	}
}
