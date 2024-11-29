using System;
using System.Collections.Generic;
using System.Data;
using DataAcessLayer;
using Microsoft.Data.SqlClient;
using ValueObject;

namespace QL_sald.DataAccessLayer
{
    internal class IngredientsDAL
    {
        private ConnectSQL connectSQL = new ConnectSQL();

        // Phương thức để lấy danh sách tất cả các nguyên liệu
        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            string query = "SELECT IngredientId, IngredientName FROM Ingredient"; // Cập nhật truy vấn SQL

            DataTable dt = connectSQL.GetData(query);

            foreach (DataRow row in dt.Rows)
            {
                Ingredient ingredient = new Ingredient
                {
                    IngredientId = Convert.ToInt32(row["IngredientId"]),
                    IngredientName = row["IngredientName"].ToString()
                };
                ingredients.Add(ingredient);
            }

            return ingredients;
        }
    }
}
