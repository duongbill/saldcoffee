using System.Collections.Generic;
using QL_sald.DataAccessLayer;
using ValueObject;

namespace QL_sald.logicLayer
{
    public class CategoriesLL
    {
        private CategoriesDAL categoriesDAL = new CategoriesDAL();

        public List<Category> GetAllCategories()
        {
            return categoriesDAL.GetAllCategories();
        }
    }
}
