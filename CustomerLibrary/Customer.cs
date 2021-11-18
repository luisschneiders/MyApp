using System;
using LocationLibrary;

namespace CustomerLibrary
{
    public class Customer
    {
        private string _customerId;
        private string _customerName;
        private int _customerAge;
        private string _customerEmail;
        private int _customerMobilePhone;
        private int _customerPhone;
        private Location _customerLocation;

        // constructor
        public Customer()
        {
        }

        // method Save
        public void Save(string customerName, int customerAge, string customerEmail, int customerMobilePhone, int customerPhone, Location customerLocation)
        {
            // Add validation for fields

            CustomerId = Guid.NewGuid().ToString();
            CustomerName = customerName;
            CustomerAge = customerAge;
            CustomerEmail = customerEmail;
            CustomerMobilePhone = customerMobilePhone;
            CustomerPhone = customerPhone;
            CustomerLocation = customerLocation;
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

        public string CustomerEmail
        {
            get => _customerEmail;
            set => _customerEmail = value;
        }

        public int CustomerMobilePhone
        {
            get => _customerMobilePhone;
            set => _customerMobilePhone = value;
        }

        public int CustomerPhone
        {
            get => _customerPhone;
            set => _customerPhone = value;
        }

        public Location CustomerLocation
        {
            get => _customerLocation;
            set => _customerLocation = value;
        }

    }
}
