using PromotionEngine.CalculationEngine.Services;
using PromotionEngine.Models;
using System;
using System.Linq;

namespace PromotionEngine.CalculationEngine
{
    public class PromotionService : IPromotion
    {
        public Item Item { get; private set; }
        public PromotionService(Item item)
        {
            Item = item;
        }

        public Cart ApplyPromotion(Cart cart)
        {
            decimal total = default;
            var items = cart.Items.Where(x => x.Product.SKU == Item.Product.SKU).ToList();

            var totalQuantityToProcess = items.Sum(x => x.Quantity);

            if (items != null && totalQuantityToProcess >= Item.Quantity)
            {
                var numberOfSets = (int)Math.Floor((decimal)totalQuantityToProcess / Item.Quantity);
                total = numberOfSets * Item.Product.Price;

                int processedProductCount = (numberOfSets * Item.Quantity);

                var unprocessedQuantity = totalQuantityToProcess - processedProductCount;

                total += unprocessedQuantity * items.FirstOrDefault().Product.Price;

                return new Cart(items, cart.Total + total);
            }

            return cart;
        }
    }
}
