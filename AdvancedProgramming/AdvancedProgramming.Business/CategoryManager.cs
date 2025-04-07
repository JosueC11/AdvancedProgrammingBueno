using AdvancedProgramming.Data;
using AdvancedProgramming.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedProgramming.Business
{
    public class CategoryManager
    {
        private readonly IRepositoryCategory _repositoryCategory;

        public CategoryManager()
        {
            _repositoryCategory = new RepositoryCategory();
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = _repositoryCategory.GetAll().ToList();
            return categories;
        }

        public object GetById(int? id)
        {
            var category = _repositoryCategory.GetById((int)id);
            return category;
        }

        public void Add(Category category)
        {
            var found = category.Products.Where(x => x.CategoryID == category.CategoryID);
            if (found != null && found.Any())
                _repositoryCategory.Add(category);
            return;
        }

        public bool Save(Category category)
        {
            _repositoryCategory.Update(category);
            return true;
        }
    }
}
