using Promotions.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.Logic.Promotions
{
    public class PromotionThreeOfA : IPromotion
    {
        const int PromotionValue = 20;

        public void Apply(Order order)
        {
            var toDiscount = order.Products
                .Where(p => !p.HasBeenDiscounted)
                .Where(p => p.Sku == "A")
                .Take(3)
                .ToList();

            if (toDiscount.Count == 3)
            {
                order.TotalDiscount += PromotionValue;
                toDiscount.ForEach(p => p.HasBeenDiscounted = true);
            }
        }
    }
}
