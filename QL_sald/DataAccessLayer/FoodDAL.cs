using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using ValueObject;

namespace QL_sald.DataAccessLayer
{
    internal class FoodDAL
    {
        private ConnectSQL connectSQL = new ConnectSQL();

        public List<Food> GetFoodData()
        {
            List<Food> foods = new List<Food>();
            string query = "SELECT FoodName, Price, ImageURL FROM Food";

            DataTable dt = connectSQL.GetData(query);

            foreach (DataRow row in dt.Rows)
            {
                Food food = new Food(
                    row["FoodName"].ToString(),
                    Convert.ToDecimal(row["Price"]),
                    row["ImageURL"].ToString()
                );
                foods.Add(food);
            }

            return foods;
        }
    }
}
