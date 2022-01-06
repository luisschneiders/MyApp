using System;
using System.Collections.Generic;
using BaseLibrary;
using ContactDetailsLibrary;
using LocationLibrary;

namespace SupplierLibrary
{
    public class Supplier : Base
    {
        private Guid _id;
        private string _supplierName;
        private string _supplierABN;
        private ContactDetails _contactDetails;
        private Location _location;

        // contructor
        public Supplier()
        {
        }

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public string SupplierName
        {
            get => _supplierName;
            set => _supplierName = value;
        }

        public string SupplierABN
        {
            get => _supplierABN;
            set => _supplierABN = value;
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
