using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class Product
    {
        public Product(string sKU, decimal price)
        {
            SKU = sKU ?? throw new ArgumentNullException(nameof(sKU));
            Price = price;
        }

        public string SKU { get; private set; }
        public decimal Price { get; private set; }
    }
}
