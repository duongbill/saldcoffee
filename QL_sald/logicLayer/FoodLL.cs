using System.Collections.Generic;
using QL_sald.DataAccessLayer;
using ValueObject;

namespace QL_sald.logicLayer
{
    internal class FoodLL
    {
        private FoodDAL foodDAL;

        public FoodLL()
        {
            foodDAL = new FoodDAL();
        }

        public List<Food> GetFoodsByCategory(int categoryId)
        {
            return foodDAL.GetFoodDataByCategory(categoryId);
        }
    }
}
