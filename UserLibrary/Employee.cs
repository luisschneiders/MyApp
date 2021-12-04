using System;
using BaseLibrary;
using ContactDetailsLibrary;
using LocationLibrary;

namespace EmployeeLibrary
{
    public class Employee : Base
    {
        private Guid _id;
        private string _employeeFirstName;
        private string _employeeLastName;
        private string _employeeUsername;
        private string _employeePassword;
        private ContactDetails _employeeContactDetails;
        private Location _employeeLocation;

        // constructor
        public Employee()
        {
        }

        // method Save
        public void Save(Employee employee)
        {
            // Add validation for fields

            Id = Guid.NewGuid();
            EmployeeUsername = employee.EmployeeUsername;
            EmployeePassword = employee.EmployeePassword;
            EmployeeContactDetails = employee.EmployeeContactDetails;
            EmployeeLocation = employee.EmployeeLocation;

            // both fields will have the same value
            CreatedAt = UpdatedAt = DateTime.UtcNow;

        }

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public string EmployeeFirstName
        {
            get => _employeeFirstName;
            set => _employeeFirstName = value;
        }

        public string EmployeeLastName
        {
            get => _employeeLastName;
            set => _employeeLastName = value;
        }

        public string EmployeeUsername
        {
            get => _employeeUsername;
            set => _employeeUsername = value;
        }

        public string EmployeePassword
        {
            get => _employeePassword;
            set => _employeePassword = value;
        }

        public ContactDetails EmployeeContactDetails
        {
            get => _employeeContactDetails;
            set => _employeeContactDetails = value;
        }

        public Location EmployeeLocation
        {
            get => _employeeLocation;
            set => _employeeLocation = value;
        }
    }
}
