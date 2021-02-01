using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Models
{
    [Table("Cart")]
    public class Cart
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; } //mby
        public float TotalPrice { get; set; }
        public Boolean Bought { get; set; }
}
}
