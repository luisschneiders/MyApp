namespace AreaLibrary.Models
{
	public class AreaDto
	{
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public Guid DepartmentId { get; set; }

        public string? DepartmentName { get; set; }
    }
}
