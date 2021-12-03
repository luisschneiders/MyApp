using System;
using BaseLibrary;
using ContactDetailsLibrary;
using LocationLibrary;

namespace CustomerLibrary
{
    public class Customer : Base
    {
        private Guid _customerId;
        private string _customerFirstName;
        private string _customerLastName;
        private int _customerAge;
        private ContactDetails _customerContactDetails;
        private Location _customerLocation;

        // constructor
        public Customer()
        {
        }

        // method Save
        public void Save(Customer customer)
        {
            // Add validation for fields

            CustomerId = Guid.NewGuid();
            CustomerFirstName = customer.CustomerFirstName;
            CustomerLastName = customer.CustomerLastName;
            CustomerAge = customer.CustomerAge;
            CustomerContactDetails = customer.CustomerContactDetails;
            CustomerLocation = customer.CustomerLocation;

            // both fields will have the same value
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }

        public Guid CustomerId
        {
            get => _customerId;
            set => _customerId = value;
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

        public int CustomerAge
        {
            get => _customerAge;
            set => _customerAge = value;
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
