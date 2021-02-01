using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.Abstractions
{
    public interface ICart : IRepository<Cart>
    {
        public IEnumerable<Cart> GetCartItems(string id);
        public void finishTransaction(string id);
        public IEnumerable<Cart> GetBoughtItems(string id);
    }
}
