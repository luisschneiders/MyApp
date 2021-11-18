using System;
using SupplierLibrary;

namespace ProductLibrary
{
    public class Product
    {
        private string _productId;
        private string _productName;
        private decimal _productInitialStock;
        private decimal _productCurrentStock;
        private object _productSupplier;

        // constructor
        public Product()
        {
        }

        // method Save
        public void Save(string productName, decimal productInitialStock, decimal productCurrentStock, Supplier productSupplier)
        {
            // Add validation for fields

            ProductId = Guid.NewGuid().ToString();
            ProductName = productName;
            ProductInitialStock = productInitialStock;
            ProductCurrentStock = productCurrentStock;
            ProductSupplier = productSupplier;

        }

        public string ProductId
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

        public object ProductSupplier
        {
            get => _productSupplier;
            set => _productSupplier = value;
        }
    }
}
