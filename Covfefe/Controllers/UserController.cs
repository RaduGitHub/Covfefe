using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Covfefe.Data;
using Covfefe.Data.Services;
using Covfefe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Covfefe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserService userService;
        private UserManager<ApplicationUser> userManager;

        public UserController(ApplicationDbContext context, UserService userService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userService = userService;
            this.userManager = userManager;
        }

        // GET: api/Products
        [HttpGet]
        //[Route("all")]
        public IQueryable<ApplicationUser> GetUsers()
        {
            return userManager.Users;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public IQueryable<ApplicationUser> GetUser(int id)
        {
            return userManager.Users.Where(u => u.Id == id.ToString());
        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<Product> PostUser(User user)
        {
            //userService(product);
            userService.AddUser(user);
            //return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
            return null;
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {


            //return product;
            return null;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
