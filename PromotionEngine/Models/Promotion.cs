using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class Promotion
    {
        public string PromotedProductSku { get; private set; }
        public int PromotionQuantity { get; private set; }
        public decimal PromotionAmount { get; private set; }
        public Promotion(string promotedProductSku, int promotionQuantity, decimal promotionAmount)
        {
            PromotedProductSku = promotedProductSku;
            PromotionQuantity = promotionQuantity;
            PromotionAmount = promotionAmount;
        }
    }
}
