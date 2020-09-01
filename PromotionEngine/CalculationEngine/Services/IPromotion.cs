using PromotionEngine.Models;

namespace PromotionEngine.CalculationEngine.Services
{
    public interface IPromotion
    {
        Cart ApplyPromotion(Cart cart);
    }
}
