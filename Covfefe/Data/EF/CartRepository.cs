using Covfefe.Data.Abstractions;
using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.EF
{
    public class CartRepository : BaseRepository<Cart>, ICart
    {
        public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Cart> GetCartItems(string id)
        {
            return dbContext.Cart.Where(c => c.UserId == id  && c.Bought == false).AsEnumerable();
        }

        public void finishTransaction(string id)
        {
            var asd = dbContext.Cart.Where(c => c.UserId == id).AsEnumerable();
            foreach(Cart cart in asd)
            {
                cart.Bought = true;
            }
            dbContext.SaveChanges();
        }

        public IEnumerable<Cart> GetBoughtItems(string id)
        {
            return dbContext.Cart.Where(c => c.Bought == true && c.UserId == id).AsEnumerable();
        }

    }
}
