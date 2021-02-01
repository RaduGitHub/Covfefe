using Covfefe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covfefe.Data.Abstractions
{
    public interface IProduct : IRepository<Product>
    {
        Product GetProduct(int ID);
        IEnumerable<Product> GetProductByFilter(FilterProduct filterProduct);
        IEnumerable<Product> GetProductByFilter(String category);
        void Delete(int id);
        IEnumerable<Product> GetProductByName(string name);
    }
}
