using System;
namespace EmployeeLibrary.Models
{
	public class EmployeeListDto
	{
        public Guid Id { get; set; }

        public string? EmployeeFirstName { get; set; }

        public string? EmployeeLastName { get; set; }

        public string? EmployeeEmail { get; set; }

        public bool IsActive { get; set; }

    }
}

