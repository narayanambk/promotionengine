using PromotionEngine.CalculationEngine.Services;
using PromotionEngine.Models;
using System;
using System.Linq;

namespace PromotionEngine.CalculationEngine
{
    public class PromotionService : IPromotion
    {
        public Promotion Promotion { get; private set; }

        public PromotionService(Promotion promotion) => Promotion = promotion;

        public Cart ApplyPromotion(Cart cart)
        {
            decimal total = default;
            var items = cart.Items.Where(x => x.Product.SKU == Promotion.PromotedProductSku).ToList();

            var totalQuantityToProcess = items.Sum(x => x.Quantity);

            if (items != null && totalQuantityToProcess >= Promotion.PromotionQuantity)
            {
                var numberOfSets = (int)Math.Floor((decimal)totalQuantityToProcess / Promotion.PromotionQuantity);
                total = numberOfSets * Promotion.PromotionAmount;

                int processedProductCount = (numberOfSets * Promotion.PromotionQuantity);

                var unprocessedQuantity = totalQuantityToProcess - processedProductCount;

                total += unprocessedQuantity * items.FirstOrDefault().Product.Price;

                return new Cart(cart.Items.Except(items).ToList(), cart.Total + total);
            }

            return cart;
        }
    }
}
