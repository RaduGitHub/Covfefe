using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Models
{
    [Table("Rating")]
    public class Rating
    {
        public int RatingId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Score { get; set; }
    }
}
