using PromotionEngine.CalculationEngine.Services;
using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.CalculationEngine
{
    public class ComboPromotionService : IPromotion
    {
        public ComboPromotionService(ComboPromotion promotion)
        {
            Promotion = promotion;
        }

        public ComboPromotion Promotion { get; private set; }

        public Cart ApplyPromotion(Cart cart)
        {
            decimal total = default;

            var items = cart.Items.Where(x => Promotion.ComboSku.Any(c => c == x.Product.SKU)).ToList();

            var numberOfCombos = Promotion.ComboSku.Select(x => items.Count(i => i.Product.SKU == x)).Min();

            if (numberOfCombos > 0)
            {
                total = Promotion.FlatPrice * numberOfCombos;

                var calculatedItems = new List<Item>();

                foreach (var sku in Promotion.ComboSku)
                {
                    calculatedItems.AddRange(items.Where(x => x.Product.SKU == sku).Take(numberOfCombos));
                }

                var uncalculatedItems = items.Except(calculatedItems);

                total += uncalculatedItems.Any() ? uncalculatedItems.Sum(x => x.Product.Price) : default;

                return new Cart(cart.Items.Except(items).ToList(), cart.Total + total);
            }
            return cart;

        }
    }
}
