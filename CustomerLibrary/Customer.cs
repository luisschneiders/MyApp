using System;
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
        private ContactDetails _customerContactDetails;
        private Location _customerLocation;

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

        public ContactDetails CustomerContactDetails
        {
            get => _customerContactDetails;
            set => _customerContactDetails = value;
        }

        public Location CustomerLocation
        {
            get => _customerLocation;
            set => _customerLocation = value;
        }

    }
}
