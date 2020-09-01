using PromotionEngine.CalculationEngine.Services;
using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.CalculationEngine
{
    public class ComboPromotion : IPromotion
    {
        public IEnumerable<Item> Items { get; private set; }
        public decimal FlatPrice { get; private set; }
        public ComboPromotion(IEnumerable<Item> item, decimal flatAmount)
        {
            Items = item;
            FlatPrice = flatAmount;
        }

        public Cart ApplyPromotion(Cart cart)
        {
            decimal total = default;

            var items = cart.Items.Where(x => Items.Any(c => c.Product.SKU == x.Product.SKU)).ToList();

            var numberOfCombos = Items.Select(x => items.Count(i => i.Product.SKU == x.Product.SKU)).Min();

            if (numberOfCombos > 0)
            {
                total = FlatPrice * numberOfCombos;

                var calculatedItems = new List<Item>();

                foreach (var sku in Items.Select(x=>x.Product.SKU))
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
