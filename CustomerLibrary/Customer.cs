using System;
using System.Collections.Generic;
using BaseLibrary;
using ContactDetailsLibrary;
using LocationLibrary;

namespace CustomerLibrary
{
    public class Customer : Base
    {
        private Guid _id;
        private string _customerFirstName;
        private string _customerLastName;
        private DateTime _customerDOB;
        private ICollection<ContactDetails> _contactDetails;
        private ICollection<Location> _location;

        // constructor
        public Customer()
        {
        }

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public string CustomerFirstName
        {
            get => _customerFirstName;
            set => _customerFirstName = value;
        }

        public string CustomerLastName
        {
            get => _customerLastName;
            set => _customerLastName = value;
        }

        public string FullName
        {
            get => $"{_customerFirstName} {_customerLastName}";
        }

        public DateTime CustomerDOB
        {
            get => _customerDOB;
            set => _customerDOB = value;
        }

        public ICollection<ContactDetails> ContactDetails
        {
            get => _contactDetails;
            set => _contactDetails = value;
        }

        public ICollection<Location> Location
        {
            get => _location;
            set => _location = value;
        }

    }
}
