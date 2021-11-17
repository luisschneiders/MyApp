using System;
using LocationLibrary;

namespace SupplierLibrary
{
    public interface ISupplier
    {
        string SupplierId { get; set; }
        string SupplierName { get; set; }
        int SupplierABN { get; set; }
        int[] SupplierPhone { get; set; }
        string[] SupplierEmail { get; set; }
    }

    public class Supplier : ISupplier , ILocation
    {
        private string _supplierId;
        private string _supplierName;
        private int _supplierABN;
        private int[] _supplierPhone;
        private string[] _supplierEmail;
        private ILocation _supplierLocation;

        // contructor
        public Supplier(string supplierName, int supplierABN, int[] supplierPhone, string[] supplierEmail, ILocation supplierLocation)
        {
            _supplierName = supplierName;
            _supplierABN = supplierABN;
            _supplierPhone = supplierPhone;
            _supplierEmail = supplierEmail;
            _supplierLocation = supplierLocation;
        }

        // method Save
        public void Save(string supplierName)
        {
            // Add validation for fields

            SupplierId = Guid.NewGuid().ToString();
            SupplierName = supplierName;
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

        public string Address { get => _supplierLocation.Address; set => _supplierLocation.Address = value; }
        public int Lat { get => _supplierLocation.Lat; set => _supplierLocation.Lat = value; }
        public int Lng { get => _supplierLocation.Lng; set => _supplierLocation.Lng = value; }
        public string Suburb { get => _supplierLocation.Suburb; set => _supplierLocation.Suburb = value; }
        public string Postcode { get => _supplierLocation.Postcode; set => _supplierLocation.Postcode = value; }
        public string State { get => _supplierLocation.State; set => _supplierLocation.State = value; }
    }
}
