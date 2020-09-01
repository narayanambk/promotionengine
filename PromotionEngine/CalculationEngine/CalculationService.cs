using PromotionEngine.CalculationEngine.Services;
using PromotionEngine.Models;
using System.Collections.Generic;

namespace PromotionEngine.CalculationEngine
{
    public class CalculationService : ICalculationEngine
    {
        public decimal Calculate(IEnumerable<Item> items, IEnumerable<IPromotion> promotions)
        {
            throw new System.NotImplementedException();
        }
    }
}
