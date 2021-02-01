using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Models
{
    public class CartProduct
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }
    }
}
