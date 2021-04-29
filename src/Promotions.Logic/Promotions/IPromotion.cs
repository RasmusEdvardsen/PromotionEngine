using Promotions.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Promotions.Logic.Promotions
{
    public interface IPromotion
    {
        public void ApplyTo(Order order);
    }
}
