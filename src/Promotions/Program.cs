using Microsoft.Extensions.DependencyInjection;
using Promotions.Logic.Promotions;
using System;

namespace Promotions
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();

            collection.AddScoped<IPromotion, PromotionThreeOfA>();
            collection.AddScoped<IPromotion, PromotionTwoOfB>();
            collection.AddScoped<IPromotion, PromotionOneOfCAndD>();
            collection.AddSingleton<Runner>();

            collection
                .BuildServiceProvider()
                .GetRequiredService<Runner>()
                .Run();
        }
    }
}
