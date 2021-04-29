using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.Entity.Models
{
    public class Product
    {
        public string Sku { get; set; }
        public int Cost { get; set; }
        public bool HasBeenDiscounted { get; set; }

        public Product(string sku, int cost)
        {
            Sku = sku;
            Cost = cost;
        }
    }
}
