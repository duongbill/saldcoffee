using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; // Sử dụng Microsoft.Data.SqlClient
using ValueObject;

namespace QL_sald.DataAccessLayer
{
    internal class FoodDAL
    {
        private ConnectSQL connectSQL = new ConnectSQL();

        public List<Food> GetFoodDataByCategory(int categoryId)
        {
            List<Food> foods = new List<Food>();
            string query = "GetTop10FoodsByCategory"; // Chỉ cần tên stored procedure, không cần 'EXEC'

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryId", categoryId)
            };

            DataTable dt = connectSQL.GetData(query, parameters);

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
