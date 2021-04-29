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
    public class TestOneOfCAndD
    {
        [Fact]
        public void TestNotEnough()
        {
            // arrange
            var products = Utility.CreateProducts(1, "C", 20, false);
            var order = Utility.CreateOrder(products, 0);
            var oneOfCAndD = new PromotionOneOfCAndD();

            // act
            oneOfCAndD.ApplyTo(order);

            // assert
            Assert.True(order.TotalDiscount == 0);
        }

        [Fact]
        public void TestMoreThanEnough()
        {
            // arrange
            var cs = Utility.CreateProducts(5, "C", 20, false);
            var ds = Utility.CreateProducts(4, "D", 15, false);
            var order = Utility.CreateOrder(cs.Union(ds), 0);
            var oneOfCAndD = new PromotionOneOfCAndD();

            // act
            oneOfCAndD.ApplyTo(order);

            // assert
            Assert.True(order.TotalDiscount == 5);
            Assert.Equal(2, order.Products.Where(p => p.HasBeenDiscounted == true).Count());
        }

        [Fact]
        public void TestExactlyEnough()
        {
            // arrange
            var cs = Utility.CreateProducts(1, "C", 20, false);
            var ds = Utility.CreateProducts(1, "D", 15, false);
            var order = Utility.CreateOrder(cs.Union(ds), 0);
            var oneOfCAndD = new PromotionOneOfCAndD();

            // act
            oneOfCAndD.ApplyTo(order);

            // assert
            Assert.True(order.TotalDiscount == 5);
            Assert.True(order.Products.All(p => p.HasBeenDiscounted == true));
        }
    }
}
