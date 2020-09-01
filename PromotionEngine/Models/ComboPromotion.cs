using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class ComboPromotion
    {
        public ComboPromotion(IEnumerable<string> comboSku, decimal flatPrice)
        {
            ComboSku = comboSku ?? throw new ArgumentNullException(nameof(comboSku));
            FlatPrice = flatPrice;
        }

        public IEnumerable<string> ComboSku { get; private set; }
        public decimal FlatPrice { get; private set; }
    }
}
