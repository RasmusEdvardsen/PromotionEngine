using Promotions.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.Logic.Promotions
{
    public class PromotionTwoOfB : IPromotion
    {
        const int PromotionValue = 15;

        public void Apply(Order order)
        {
            var toDiscount = order.Products
                .Where(p => !p.HasBeenDiscounted)
                .Where(p => p.Sku == "B")
                .Take(2)
                .ToList();

            if (toDiscount.Count == 2)
            {
                order.TotalDiscount += PromotionValue;
                toDiscount.ForEach(p => p.HasBeenDiscounted = true);
            }
        }
    }
}
