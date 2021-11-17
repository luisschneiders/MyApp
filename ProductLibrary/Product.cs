using System;
using SupplierLibrary;

namespace ProductLibrary
{
    public class Product : ISupplier
    {
        private string _productId;
        private string _productName;
        private decimal _productInitialStock;
        private decimal _productCurrentStock;
        private ISupplier _productSupplier;

        // constructor
        public Product()
        {
        }

        // method Save
        public void Save(string productName)
        {
            // Add validation for fields

            ProductId = Guid.NewGuid().ToString();
            ProductName = productName;
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

        public string SupplierId { get => _productSupplier.SupplierId; set => _productSupplier.SupplierId = value; }
        public string SupplierName { get => _productSupplier.SupplierName; set => _productSupplier.SupplierName = value; }
        public int SupplierABN { get => _productSupplier.SupplierABN; set => _productSupplier.SupplierABN = value; }
        public int[] SupplierPhone { get => _productSupplier.SupplierPhone; set => _productSupplier.SupplierPhone = value; }
        public string[] SupplierEmail { get => _productSupplier.SupplierEmail; set => _productSupplier.SupplierEmail = value; }
    }
}
