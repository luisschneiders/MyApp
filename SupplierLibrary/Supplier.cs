using System;
using System.Collections.Generic;
using ContactDetailsLibrary;
using LocationLibrary;

namespace SupplierLibrary
{
    public class Supplier
    {
        private string _supplierId;
        private string _supplierName;
        private int _supplierABN;
        private ContactDetails _supplierContactDetails;
        private List<Location> _supplierLocation; // supplier can have multiple locations

        // contructor
        public Supplier()
        {
        }

        // method Save
        public void Save(string supplierName, int supplierABN, ContactDetails supplierContactDetails, List<Location> supplierLocation)
        {
            // Add validation for fields

            SupplierId = Guid.NewGuid().ToString();
            SupplierName = supplierName;
            SupplierABN = supplierABN;
            SupplierContactDetails = supplierContactDetails;
            SupplierLocation = supplierLocation;
        }

        public string SupplierId
        {
            get => _supplierId;
            set => _supplierId = value;
        }

        public string SupplierName
        {
            get => _supplierName;
            set => _supplierName = value;
        }

        public int SupplierABN
        {
            get => _supplierABN;
            set => _supplierABN = value;
        }

        public ContactDetails SupplierContactDetails
        {
            get => _supplierContactDetails;
            set => _supplierContactDetails = value;
        }

        public List<Location> SupplierLocation
        {
            get => _supplierLocation;
            set => _supplierLocation = value;
        }
    }
}
