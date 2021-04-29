using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.Entity.Models
{
    public class Order
    {
        public IEnumerable<Product> Products { get; set; }
        public int TotalDiscount { get; set; } = 0;

        public Order(IEnumerable<Product> products)
        {
            Products = products;
        }
    }
}
