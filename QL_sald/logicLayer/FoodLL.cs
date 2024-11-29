using QL_sald.DataAccessLayer;
using ValueObject;
using System.Collections.Generic;
using System;

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
            try
            {
                return foodDAL.GetFoodDataByCategory(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách món ăn: {ex.Message}");
            }
        }

        public void AddFood(Food food)
        {
            try
            {
                foodDAL.AddFood(food);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm món ăn: {ex.Message}");
            }
        }

        public List<Food> GetAllFoods()
        {
            try
            {
                return foodDAL.GetAllFoods();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách tất cả món ăn: {ex.Message}");
            }
        }
    }
}