using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ValueObject
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; } = string.Empty; // Tránh null reference
        public int CategoryId { get; set; }
        public int IngredientId { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; } = string.Empty; // Cũng nên có giá trị mặc định

        // Hàm tạo không tham số
        public Food() { }

        // Hàm tạo có tham số
        public Food(string foodName, decimal price, string imageURL)
        {
            FoodName = foodName;
            Price = price;
            ImageURL = imageURL;
        }

        // Hàm tạo từ DataRow
        public Food(DataRow row)
        {
            FoodId = (int)row["FoodId"];
            FoodName = row["FoodName"].ToString();
            CategoryId = (int)row["CategoryId"];
            IngredientId = (int)row["IngredientId"];
            Price = (decimal)row["Price"];
            ImageURL = row["ImageURL"].ToString();
        }
    }
}
