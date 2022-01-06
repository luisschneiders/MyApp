using System;
using System.Collections.Generic;
using BaseLibrary;
using SupplierLibrary;

namespace ProductLibrary
{
    public class Product : Base
    {
        private Guid _id;
        private string _productName;
        private decimal _productInitialStock;
        private decimal _productCurrentStock;
        private string _productSerialNumber;
        private DateTime _productManufactureDate;
        private DateTime _productExpireDate;
        private Supplier _productSupplier;

        // constructor
        public Product()
        {
        }

        public Guid Id
        {
            get => _id;
            set => _id = value;
        }

        public string ProductName
        {
            get => _productName;
            set => _productName = value;
        }

        public decimal ProductInitialStock
        {
            get => _productInitialStock;
            set => _productInitialStock = value;
        }

        public decimal ProductCurrentStock
        {
            get => _productCurrentStock;
            set => _productCurrentStock = value;
        }

        public string ProductSerialNumber
        {
            get => _productSerialNumber;
            set => _productSerialNumber = value;
        }

        public DateTime ProductManufactureDate
        {
            get => _productManufactureDate;
            set => _productManufactureDate = value;
        }

        public DateTime ProductExpireDate
        {
            get => _productExpireDate;
            set => _productExpireDate = value;
        }

        public Supplier ProductSupplier
        {
            get => _productSupplier;
            set => _productSupplier = value;
        }
    }
}
