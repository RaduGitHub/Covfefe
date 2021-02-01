using AutoMapper.Configuration;
using Covfefe.Data.Abstractions;
using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.EF
{
    public class ProductRepository : BaseRepository<Product>, IProduct
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public void Delete(int id)
        {
            var product = dbContext.Products.Where(x => x.ProductId == id).SingleOrDefault();
            Delete(product);
        }

        public Product GetProduct(int ID)
        {
            return dbContext.Products.Where(x => x.ProductId == ID).SingleOrDefault();
        }

        public IEnumerable<Product> GetProductByFilter(FilterProduct filterProduct)
        {
            //var query = Enumerable.Empty<Product>().AsQueryable();

            //var filterBy = filterProduct.FilterBy.Trim().ToLowerInvariant();
            var low = filterProduct.low;
            var high = filterProduct.high;
            var ascending = filterProduct.ascending;
            var descending = filterProduct.descending;
            var category = filterProduct.category;

            var products = GetAll();

            if (low != 0 && high != 0)
            {
                products = products.Where(p => p.Price > low && p.Price < high).AsEnumerable();
            }

            if (ascending == true)
            {
                products = products.OrderBy(p => p.Price);
            }

            if (descending == true)
            {
                products = products.OrderByDescending(p => p.Price);
            }

            if (category == "Cafea")
            {
                products = products.Where(p => p.ProductTypeId == 1).AsEnumerable();
            }

            if (category == "Espressor")
            {
                products = products.Where(p => p.ProductTypeId == 2).AsEnumerable();
            }

            if (category == "Unelte")
            {
                products = products.Where(p => p.ProductTypeId == 3).AsEnumerable();
            }

            return products;
            //return query.ToList();
        }

        public IEnumerable<Product> GetProductByFilter(String category)
        {
            var products = GetAll();
            if (category == "Cafea")
            {
                products = products.Where(p => p.ProductTypeId == 1).AsEnumerable();
            }

            if (category == "Espressor")
            {
                products = products.Where(p => p.ProductTypeId == 2).AsEnumerable();
            }

            if (category == "Micunelte")
            {
                products = products.Where(p => p.ProductTypeId == 3).AsEnumerable();
            }
            return products;
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            return dbContext.Products.Where(p => p.Name.Contains(name) == true || p.Description.Contains(name) == true).AsEnumerable();
        }
    }
}
