using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Models
{
    [Table("Product")]
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NOComments { get; set; }
        //public IEnumerable<Comment> Comments { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public int Score { get; set; }//rating mby
        //public string Furnizor { get; set; }


    }
}
