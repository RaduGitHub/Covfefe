using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Models
{
    [Table("ProductType")]
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string Type { get; set; }
    }
}
