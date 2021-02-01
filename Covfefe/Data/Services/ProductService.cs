using Covfefe.Data.Abstractions;
using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.Services
{
    public class ProductService
    {
        private IProduct productRepository;

        public ProductService(IProduct productRepository)
        {
            this.productRepository = productRepository;
        }

        public Product GetProduct(int ID)
        {
            return productRepository.GetProduct(ID);
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public void AddProduct(Product p)
        {
            productRepository.Add(p);
        }

        public void DeleteProduct(int id)
        {
            productRepository.Delete(id);
        }

        public IEnumerable<Product> GetProductByFilter(FilterProduct filterProduct)
        {
            return productRepository.GetProductByFilter(filterProduct);
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            return productRepository.GetProductByName(name);
        }
        public IEnumerable<Product> GetProductByFilter(String category)
        {
            return productRepository.GetProductByFilter(category);
        }
    }
}
