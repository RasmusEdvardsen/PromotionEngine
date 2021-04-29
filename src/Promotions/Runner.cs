using Promotions.Entity.Models;
using Promotions.Logic.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions
{
    public class Runner
    {
        private readonly IEnumerable<IPromotion> _promotions;

        public Runner(IEnumerable<IPromotion> promotions)
        {
            _promotions = promotions;
        }

        public void Run()
        {
            Console.WriteLine($"Active promotions: {string.Join(", ", _promotions.Select(p => p.GetType().Name))}.\n");

            Console.WriteLine("Mocking user input...");
            var products = Enumerable.Repeat(new Product("A", 50), 4);
            var order = new Order(products);
            Console.WriteLine("Mocked user input. Calculating total savings...\n");

            foreach (var promotion in _promotions)
            {
                promotion.Apply(order);
            }

            Console.WriteLine($"Done! Total savings: {order.TotalDiscount}.");
        }
    }
}
