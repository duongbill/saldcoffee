using System.Collections.Generic;
using System.Data;
using System;
using ValueObject;
using Microsoft.Data.SqlClient;
using QL_sald.DataAccessLayer;
using DataAcessLayer;
using QL_sald.ValueObject;

internal class FoodDAL
{

    private static FoodDAL instance;
    private ConnectSQL connectSQL = new ConnectSQL();
    private string connectionString = "Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;TrustServerCertificate=True;";

    // Singleton instance
    public static FoodDAL Instance
    {
        get { if (instance == null) instance = new FoodDAL(); return instance; }
        private set { instance = value; }
    }

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
            throw new Exception($"Loin: {ex.Message}");
        }

        return foods;
    }


    public List<FoodBill> GetFoodDataByCategoryID(int categoryId)
    {
        List<FoodBill> listFoodBill = new List<FoodBill>();
        ConnectSQL connectSQL = new ConnectSQL();

        // Tên stored procedure
        string query = "GetFoodsByCategory";

        // Thêm tham số để lọc theo CategoryId
        SqlParameter[] parameters = new SqlParameter[]
        {
        new SqlParameter("@CategoryId", SqlDbType.Int) { Value = categoryId }
        };

        // Gọi stored procedure và lấy dữ liệu
        DataTable data = connectSQL.GetData(query, parameters);

        foreach (DataRow row in data.Rows)
        {
            // Giả sử lớp FoodBill có constructor nhận DataRow
            FoodBill fb = new FoodBill(row);
            listFoodBill.Add(fb);
        }

        return listFoodBill;
    }


    public List<TableFood> LoadTableList()
    {
        List<TableFood> tableList = new List<TableFood>();
        ConnectSQL connectSQL = new ConnectSQL();
        DataTable data = connectSQL.GetData("GetTableList");

        foreach (DataRow row in data.Rows)
        {
            TableFood table = new TableFood(row);
            tableList.Add(table);
        }
        return tableList;
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
            throw new Exception($"L?i khi thêm món an: {ex.Message}");
        }
    }

    public List<Food> GetAllFoods()
    {
        List<Food> foods = new List<Food>();
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

    public decimal GetFoodPriceById(int foodId)
    {
        try
        {
            // Truy vấn lấy giá của món ăn từ cơ sở dữ liệu

            string query = "SELECT Price FROM Food WHERE FoodId = @FoodId";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@FoodId", foodId)
            };

            // Sử dụng ExecuteScaler để lấy giá trị duy nhất (Price)
            object result = connectSQL.ExecuteScaler(query, parameters);

            if (result != null && result != DBNull.Value)
            {
                return Convert.ToDecimal(result);
            }
            else
            {
                throw new Exception($"Không tìm thấy món ăn với FoodId: {foodId}.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Lỗi khi lấy giá của món ăn: {ex.Message}");
        }
    }








}
