using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Models
{
    public class FilterProduct
    {
        //public string FilterBy { get; set; } = "";
        public FilterProduct()
        {
            low = 0;
            high = 0;
            ascending = false;
            descending = false;
            category = "";
        }

        public int low { get; set; }
        public int high { get; set; }
        public bool ascending { get; set; }
        public bool descending { get; set; }
        public string category { get; set; }
    }
}
