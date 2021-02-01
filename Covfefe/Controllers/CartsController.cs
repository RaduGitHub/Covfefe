using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Covfefe.Data;
using Covfefe.Models;
using Covfefe.Data.Services;

namespace Covfefe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ProductService productService;
        private CartServices cartService;

        public CartsController(ApplicationDbContext context, CartServices cartService)
        {
            _context = context;
            this.cartService = cartService;
        }

        // GET: api/Carts
        [HttpGet]
        [Route("~/api/Carts")]
        [Route("~/Carts")]
        public IEnumerable<Cart> GetCart()
        {
            return cartService.GetAll();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public IEnumerable<Cart> GetCart(string id)
        {
            return cartService.GetCartItems(id);
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public void PutCart(string id)
        {
            cartService.finishTransaction(id);
        }

        // POST: api/Carts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostCart(Cart pd)
        {

            cartService.AddCartItem(pd);

            /*_context.Cart.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCart", new { id = cart.CartId }, cart);*/
        }

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cart>> DeleteCart(int id)
        {
            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Cart.Remove(cart);
            await _context.SaveChangesAsync();

            return cart;
        }

        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartId == id);
        }
    }
}
