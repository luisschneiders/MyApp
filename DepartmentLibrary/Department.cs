using System;

namespace DepartmentLibrary
{
    public class Department
    {
        private string _departmentID;
        private string _departmentName;

        // constructor
        public Department()
        {
        }

        // method Save
        public void Save(string departmentName)
        {
            // Add validation for fields

            DepartmentId = Guid.NewGuid().ToString();
            DepartmentName = departmentName;
            
        }

        public string DepartmentId
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
