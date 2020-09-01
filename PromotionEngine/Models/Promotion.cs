using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class Promotion
    {
        public char PromotedProductSku { get; private set; }
        public int PromotionQuantity { get; private set; }
        public decimal PromotionAmount { get; private set; }
        public Promotion(char promotedProductSku, int promotionQuantity, decimal promotionAmount)
        {
            PromotedProductSku = promotedProductSku;
            PromotionQuantity = promotionQuantity;
            PromotionAmount = promotionAmount;
        }
    }
}
