using QL_sald.DataAccessLayer;
using ValueObject;
using System.Collections.Generic;
using System;
using DataAcessLayer;

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
                throw new Exception($"Lỗi: {ex.Message}");
            }
        }
        public List<FoodBill> GetFoodDataByCategoryID(int categoryId)
        {
            try
            {
                List<FoodBill> foods = foodDAL.GetFoodDataByCategoryID(categoryId);
                return foods;
            }
            catch (Exception ex)
            {
                throw new Exception($"Loi: {ex.Message}");
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
                throw new Exception($"Lỗi: {ex.Message}");
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
                throw new Exception($"Lỗi: {ex.Message}");
            }
        }

        public decimal GetFoodPriceById(int foodId)
        {
            try
            {
                return foodDAL.GetFoodPriceById(foodId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi: {ex.Message}");
            }


        }
    }
}