using System;
using BaseLibrary;

namespace DepartmentLibrary
{
    public class Department : Base
    {
        private Guid _departmentID;
        private string _departmentName;

        // constructor
        public Department()
        {
        }

        // method Save
        public void Save(Department department)
        {
            // Add validation for fields

            DepartmentId = Guid.NewGuid();
            DepartmentName = department.DepartmentName;

            // both fields will have the same value
            CreatedAt = UpdatedAt = DateTime.UtcNow;

        }

        public Guid DepartmentId
        {
            get => _departmentID;
            set => _departmentID = value;
        }

        public string DepartmentName
        {
            get => _departmentName;
            set => _departmentName = value;
        }

    }
}
