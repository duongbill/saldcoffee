using System;
using System.Collections.Generic;
using System.Data;
using DataAcessLayer;
using Microsoft.Data.SqlClient; 
using ValueObject;

namespace QL_sald.DataAccessLayer
{
    public class IngredientsDAL
    {
        private ConnectSQL connectSQL = new ConnectSQL();

        // Phương thức để lấy danh sách tất cả nguyên liệu
        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> listIngredients = new List<Ingredient>();

            string query = "SELECT IngredientName, SoLuong, ImageURL FROM Ingredient"; // Truy vấn SELECT đơn giản

            DataTable data = connectSQL.GetData(query);

            foreach (DataRow row in data.Rows)
            {
                Ingredient ingredient = new Ingredient
                {
                    IngredientName = row["IngredientName"].ToString(),
                    SoLuong = (int)row["SoLuong"],
                    ImageURL = row["ImageURL"].ToString()
                };
                listIngredients.Add(ingredient);
            }

            return listIngredients;
        }

        // Phương thức để lấy danh sách nguyên liệu theo Id
        public List<Ingredient> GetIngredientsById(int ingredientId)
        {
            List<Ingredient> listIngredients = new List<Ingredient>();

            string query = "SELECT IngredientName, SoLuong, ImageURL FROM Ingredient WHERE IngredientId = @IngredientId";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IngredientId", SqlDbType.Int) { Value = ingredientId }
            };

            DataTable data = connectSQL.GetData(query, parameters);

            foreach (DataRow row in data.Rows)
            {
                Ingredient ingredient = new Ingredient
                {
                    IngredientName = row["IngredientName"].ToString(),
                    SoLuong = (int)row["SoLuong"],
                    ImageURL = row["ImageURL"].ToString()
                };
                listIngredients.Add(ingredient);
            }

            return listIngredients;
        }
    }
}
