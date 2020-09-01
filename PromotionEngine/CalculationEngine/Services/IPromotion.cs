using PromotionEngine.Models;

namespace PromotionEngine.CalculationEngine.Services
{
    interface IPromotion
    {
        Cart ApplyPromotion(Cart cart);
    }
}
