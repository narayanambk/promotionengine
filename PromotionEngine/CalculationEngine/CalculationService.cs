using PromotionEngine.CalculationEngine.Services;
using PromotionEngine.Models;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.CalculationEngine
{
    public class CalculationService : ICalculationEngine
    {
        public decimal Calculate(IEnumerable<Item> items, IEnumerable<IPromotion> promotions)
        {
            var casherCart = new Cart(items.ToList());

            foreach (var promotion in promotions)
            {
                casherCart = promotion.ApplyPromotion(casherCart);
            }
            var leftoverItemsCost = casherCart.Items.Any() ? casherCart.Items.Sum(x => x.Product.Price) : default;

            return casherCart.Total + leftoverItemsCost;
        }
    }
}
