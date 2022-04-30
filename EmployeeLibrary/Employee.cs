using System;
using System.Collections.Generic;
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
        private ContactDetails _contactDetails;
        private Location _location;

        // constructor
        public Employee()
        {
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

        public ContactDetails ContactDetails
        {
            get => _contactDetails;
            set => _contactDetails = value;
        }

        public Location Location
        {
            get => _location;
            set => _location = value;
        }
    }
}
