using System;
using LocationLibrary;

namespace SupplierLibrary
{
    public class Supplier
    {
        private string _supplierId;
        private string _supplierName;
        private int _supplierABN;
        private int[] _supplierPhone;
        private string[] _supplierEmail;
        private object _supplierLocation;

        // contructor
        public Supplier()
        {
        }

        // method Save
        public void Save(string supplierName, int supplierABN, int[] supplierPhone, string[] supplierEmail, Location supplierLocation)
        {
            // Add validation for fields

            SupplierId = Guid.NewGuid().ToString();
            SupplierName = supplierName;
            SupplierABN = supplierABN;
            SupplierPhone = supplierPhone;
            SupplierEmail = supplierEmail;
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

        public int[] SupplierPhone
        {
            get => _supplierPhone;
            set => _supplierPhone = value;
        }

        public string[] SupplierEmail
        {
            get => _supplierEmail;
            set => _supplierEmail = value;
        }

        public object SupplierLocation
        {
            get => _supplierLocation;
            set => _supplierLocation = value;
        }
    }
}
