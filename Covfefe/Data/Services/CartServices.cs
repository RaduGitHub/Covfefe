using Covfefe.Data.Abstractions;
using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.Services
{
    public class CartServices
    {
        private ICart cartRepository;
        public CartServices(ICart cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public IEnumerable<Cart> GetAll()
        {
            return cartRepository.GetAll();
        }

        public void AddComment(Cart c)
        {
            cartRepository.Add(c);
        }

        public void AddCartItem(Cart p)
        {
            cartRepository.Add(p);
        }

        public IEnumerable<Cart> GetCartItems(string id)
        {
            return cartRepository.GetCartItems(id);
        }

        public void finishTransaction(string id)
        {
            cartRepository.finishTransaction(id);
        }

        public IEnumerable<Cart> GetBoughtItems(string id)
        {
            return cartRepository.GetBoughtItems(id);
        }
    }
}
