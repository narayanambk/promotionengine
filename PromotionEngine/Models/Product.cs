using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class Product
    {
        public string SKU { get; private set; }
        public decimal Price { get; private set; }

        public Product(string sku, decimal price)
        {
            SKU = sku;
            Price = price;
        }
    }
}
