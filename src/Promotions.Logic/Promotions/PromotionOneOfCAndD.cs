using Promotions.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.Logic.Promotions
{
    public class PromotionOneOfCAndD : IPromotion
    {
        const int PromotionValue = 5;

        public void Apply(Order order)
        {
            var c = order.Products
                .FirstOrDefault(p => !p.HasBeenDiscounted && p.Sku == "C");
            var d = order.Products
                .FirstOrDefault(p => !p.HasBeenDiscounted && p.Sku == "D");

            if (c is not null && d is not null)
            {
                order.TotalDiscount += PromotionValue;
                new List<Product> { c, d }.ForEach(p => p.HasBeenDiscounted = true);
            }
        }
    }
}
