using PromotionEngine.Models;
using System.Collections.Generic;

namespace PromotionEngine.CalculationEngine.Services
{
    interface ICalculationEngine
    {
        decimal Calculate(IEnumerable<Item> items, IEnumerable<IPromotion> promotions);
    }
}
