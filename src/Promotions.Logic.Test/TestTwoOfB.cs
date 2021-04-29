using AutoFixture;
using Moq;
using Promotions.Entity.Models;
using Promotions.Logic.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Promotions.Logic.Test
{
    public class TestTwoOfB
    {
        [Fact]
        public void TestOnlyOne()
        {
            // arrange
            var products = Utility.CreateProducts(1, "B", 30, false);
            var order = Utility.CreateOrder(products, 0);
            var threeOfA = new PromotionTwoOfB();

            // act
            threeOfA.ApplyTo(order);

            // assert
            Assert.True(order.TotalDiscount == 0);
        }

        [Fact]
        public void TestMoreThanThree()
        {
            // arrange
            var products = Utility.CreateProducts(10, "B", 30, false);
            var order = Utility.CreateOrder(products, 0);
            var threeOfA = new PromotionTwoOfB();

            // act
            threeOfA.ApplyTo(order);

            // assert
            Assert.True(order.TotalDiscount == 15);
            Assert.True(order.Products.Take(2).All(p => p.HasBeenDiscounted == true));
        }

        [Fact]
        public void TestExactlyThree()
        {
            // arrange
            var products = Utility.CreateProducts(2, "B", 30, false);
            var order = Utility.CreateOrder(products, 0);
            var threeOfA = new PromotionTwoOfB();

            // act
            threeOfA.ApplyTo(order);

            // assert
            Assert.True(order.TotalDiscount == 15);
            Assert.True(order.Products.All(p => p.HasBeenDiscounted == true));
        }
    }
}
