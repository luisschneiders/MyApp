using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BaseLibrary.Models;

namespace LabelLibrary.Models
{
    public abstract class Label : Base
    {
        [Required]
        public string? CompanyName { get; set; }

        /*
         * InputSelect does not validate type GUID at this stage, so we will use type String
         */
        [Required]
        public string? DepartmentId { get; set; }

        [Required]
        public string? Location { get; set; }

    }
}
