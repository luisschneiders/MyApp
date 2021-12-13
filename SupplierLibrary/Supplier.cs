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
        private ICollection<ContactDetails> _supplierContactDetails;
        private ICollection<Location> _supplierLocation;

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

        public ICollection<ContactDetails> SupplierContactDetails
        {
            get => _supplierContactDetails;
            set => _supplierContactDetails = value;
        }

        public ICollection<Location> SupplierLocation
        {
            get => _supplierLocation;
            set => _supplierLocation = value;
        }
    }
}
