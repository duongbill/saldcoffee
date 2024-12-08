using QL_sald.DataAccessLayer;
using ValueObject;
using System.Collections.Generic;

namespace QL_sald.logicLayer
{
    public class IngredientsLL
    {
        private IngredientsDAL ingredientsDAL = new IngredientsDAL();

        // Phương thức để lấy danh sách tất cả nguyên liệu
        public List<Ingredient> GetAllIngredients()
        {
            return ingredientsDAL.GetAllIngredients();
        }

        // Phương thức để lấy danh sách nguyên liệu theo Id
        public List<Ingredient> GetIngredientsById(int ingredientId)
        {
            return ingredientsDAL.GetIngredientsById(ingredientId);
        }
    }
}
