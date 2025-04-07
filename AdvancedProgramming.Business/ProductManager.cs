using AdvancedProgramming.Architecture.Validations;
using AdvancedProgramming.Architecture.Extensions;
using AdvancedProgramming.Data;
using AdvancedProgramming.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgramming.Business
{
    public class ProductManager
    {
        private readonly RepositoryProduct _repository;
        public ProductManager()
        {
            _repository = new RepositoryProduct();
        }

        public bool Save(Product product)
        {
            var results = new List<bool>
            {
                ManagerValidator.ValueIsLessThan(product, product.Rating ?? 0, 4.50M, ((p) => { product.Description += "Class B product"; })),
                product.HasCategoryID()
            };

            if (results.All(x => x))
            {
                _repository.Update(product);
                return true;
            }

            product.Description += "Class A product";
            _repository.Update(product);

            return true;
        }
    }
}
