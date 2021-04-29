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
    public class TestThreeOfA
    {
        [Fact]
        public void TestLessThanThree()
        {
            // arrange
            var products = Utility.CreateProducts(2, "A", 50, false);
            var order = Utility.CreateOrder(products, 0);
            var threeOfA = new PromotionThreeOfA();

            // act
            threeOfA.ApplyTo(order);

            // assert
            Assert.True(order.TotalDiscount == 0);
        }

        [Fact]
        public void TestMoreThanThree()
        {
            // arrange
            var products = Utility.CreateProducts(10, "A", 50, false);
            var order = Utility.CreateOrder(products, 0);
            var threeOfA = new PromotionThreeOfA();

            // act
            threeOfA.ApplyTo(order);

            // assert
            Assert.True(order.TotalDiscount == 20);
            Assert.True(order.Products.Take(3).All(p => p.HasBeenDiscounted == true));
        }

        [Fact]
        public void TestExactlyThree()
        {
            // arrange
            var products = Utility.CreateProducts(3, "A", 50, false);
            var order = Utility.CreateOrder(products, 0);
            var threeOfA = new PromotionThreeOfA();

            // act
            threeOfA.ApplyTo(order);

            // assert
            Assert.True(order.TotalDiscount == 20);
            Assert.True(order.Products.All(p => p.HasBeenDiscounted == true));
        }
    }
}
