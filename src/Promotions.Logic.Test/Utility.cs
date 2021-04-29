using AutoFixture;
using Promotions.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.Logic.Test
{
    public static class Utility
    {
        private static readonly Fixture fixture = new Fixture();

        public static IEnumerable<Product> CreateProducts(int count, string sku, int cost, bool hasBeenDiscounted = false)
        {
            return fixture.Build<Product>()
                .With(p => p.HasBeenDiscounted, hasBeenDiscounted)
                .With(p => p.Cost, cost)
                .With(p => p.Sku, sku)
                .CreateMany(count);
        }

        public static Order CreateOrder(IEnumerable<Product> products, int totalDiscount)
        {
            return fixture.Build<Order>()
                .With(o => o.Products, products)
                .With(o => o.TotalDiscount, totalDiscount)
                .Create();
        }
    }
}
