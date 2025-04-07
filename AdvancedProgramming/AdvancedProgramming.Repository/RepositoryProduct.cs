using AdvancedProgramming.Data;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AdvancedProgramming.Repository
{
    public interface IRepositoryProduct : IRepositoryBase<Product>
    {
    }

    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        public RepositoryProduct() : base()
        {
        }

        public IEnumerable<Product> GetProductsX(int id)
        {
            /*var product = from p in _context.Products.ToList()
            where p.ProductID == id
            select p;

            return product;*/

            return _context.Products.Where(x => x.ProductID == id).ToList();
        }
    }

}
