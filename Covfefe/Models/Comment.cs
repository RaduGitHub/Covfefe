using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Models
{
    [Table("Comment")]
    public class Comment
    {
        public int CommentID { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
