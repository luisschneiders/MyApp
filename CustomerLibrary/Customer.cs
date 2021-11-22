using System;
using BaseLibrary;
using ContactDetailsLibrary;
using LocationLibrary;

namespace CustomerLibrary
{
    public class Customer : Base
    {
        private string _customerId;
        private string _customerName;
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

            CustomerId = Guid.NewGuid().ToString();
            CustomerName = customer.CustomerName;
            CustomerAge = customer.CustomerAge;
            CustomerContactDetails = customer.CustomerContactDetails;
            CustomerLocation = customer.CustomerLocation;

            // both fields will have the same value
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }

        public string CustomerId
        {
            get => _customerId;
            set => _customerId = value;
        }

        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
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
