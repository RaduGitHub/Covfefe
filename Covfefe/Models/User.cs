using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Models
{
    public class User : ApplicationUser
    {
        public string Address { get; set; }
        public int gender { get; set; }
    }
}
