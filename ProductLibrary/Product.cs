using System;
using System.Collections.Generic;
using BaseLibrary;
using SupplierLibrary;

namespace ProductLibrary
{
    public class Product : Base
    {
        private Guid _productId;
        private string _productName;
        private decimal _productInitialStock;
        private decimal _productCurrentStock;
        private string _productSerialNumber;
        private DateTime _productManufactureDate;
        private DateTime _productExpireDate;
        private List<Supplier> _productSupplier;

        // constructor
        public Product()
        {
        }

        // method Save
        public void Save(Product product)
        {
            // Add validation for fields

            ProductId = Guid.NewGuid();
            ProductName = product.ProductName;
            ProductInitialStock = product.ProductInitialStock;
            ProductCurrentStock = product.ProductCurrentStock;
            ProductSerialNumber = product.ProductSerialNumber;
            ProductManufactureDate = product.ProductManufactureDate;
            ProductExpireDate = product.ProductExpireDate;
            ProductSupplier = product.ProductSupplier;

            // both fields will have the same value
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }

        public Guid ProductId
        {
            get => _productId;
            set => _productId = value;
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

        public List<Supplier> ProductSupplier
        {
            get => _productSupplier;
            set => _productSupplier = value;
        }
    }
}
