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
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ProductService productService;

        public ProductsController(ApplicationDbContext context, ProductService productService)
        {
            _context = context;
            this.productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        //[Route("api/Products")]
        //[Route("all")]
        public IEnumerable<Product> GetProducts([FromQuery] FilterProduct filterProduct)
        {
            //return productService.GetAll();

            return productService.GetProductByFilter(filterProduct);
        }
        
        //GET: api/producs/{string}
        [HttpGet]
        [Route("api/Products")]
        public IEnumerable<Product> GetProducts(String category)
        {
            //return productService.GetAll();

            return productService.GetProductByFilter(category);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return productService.GetProduct(id);

            //
        }

        [HttpGet("search/{name}")]
        public IEnumerable<Product> GetProduct(string name)
        {

            return productService.GetProductByName(name);

        }

        // POST: api/Products
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostProduct(Product product)
        {
            productService.AddProduct(product);

            //return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
            //return null;
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            productService.DeleteProduct(id);

        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
