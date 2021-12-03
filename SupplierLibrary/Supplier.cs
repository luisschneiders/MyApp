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
        private ContactDetails _supplierContactDetails;
        private Location _supplierLocation;

        // contructor
        public Supplier()
        {
        }

        // method Save
        public void Save(Supplier supplier)
        {
            // Add validation for fields

            Id = Guid.NewGuid();
            SupplierName = supplier.SupplierName;
            SupplierABN = supplier.SupplierABN;
            SupplierContactDetails = supplier.SupplierContactDetails;
            SupplierLocation = supplier.SupplierLocation;

            // both fields will have the same value
            CreatedAt = UpdatedAt = DateTime.UtcNow;
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

        public ContactDetails SupplierContactDetails
        {
            get => _supplierContactDetails;
            set => _supplierContactDetails = value;
        }

        public Location SupplierLocation
        {
            get => _supplierLocation;
            set => _supplierLocation = value;
        }
    }
}
