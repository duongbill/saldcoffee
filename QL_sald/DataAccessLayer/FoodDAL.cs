using DataAcessLayer;
using System.Collections.Generic;
using System.Data;
using System;
using ValueObject;
using Microsoft.Data.SqlClient;

internal class FoodDAL
{
    private ConnectSQL connectSQL = new ConnectSQL();

    public List<Food> GetFoodDataByCategory(int categoryId)
    {
        List<Food> foods = new List<Food>();
        string query = "GetTop10FoodsByCategory";

        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@CategoryId", categoryId)
        };

        try
        {
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
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi lấy dữ liệu món ăn: {ex.Message}");
        }

        return foods;
    }

    public void AddFood(Food food)
    {
        string query = "INSERT INTO Foods (FoodName, CategoryId, IngredientId, Price, ImageURL) VALUES (@FoodName, @CategoryId, @IngredientId, @Price, @ImageURL)";
        SqlParameter[] parameters = new SqlParameter[]
        {
            new SqlParameter("@FoodName", food.FoodName),
            new SqlParameter("@CategoryId", food.CategoryId),
            new SqlParameter("@IngredientId", food.IngredientId),
            new SqlParameter("@Price", food.Price),
            new SqlParameter("@ImageURL", food.ImageURL)
        };

        try
        {
            connectSQL.ExecuteSQL(query, parameters);
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi thêm món ăn: {ex.Message}");
        }
    }

    public List<Food> GetAllFoods()
    {
        List<Food> foods = new List<Food>();
        string connectionString = "Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;TrustServerCertificate=True;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Food";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Food food = new Food
                {
                    FoodId = reader.GetInt32(0),
                    FoodName = reader.GetString(1),
                    CategoryId = reader.GetInt32(2),
                    IngredientId = reader.GetInt32(3),
                    Price = reader.GetDecimal(4),
                    ImageURL = reader.GetString(5)
                };
                foods.Add(food);
            }
            reader.Close();
        }
        return foods;
    }
}