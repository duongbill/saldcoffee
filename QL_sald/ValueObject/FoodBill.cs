using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ValueObject
{
    public class FoodBill
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; } = string.Empty; // Tránh null reference
        public int CategoryId { get; set; }
        public int IngredientId { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; } = string.Empty; // Cũng nên có giá trị mặc định

        // Hàm tạo không tham số
        public FoodBill() { }

        // Hàm tạo có tham số
        public FoodBill(int id, string name, int categoryId, decimal price)
        {
            this.FoodId = id;
            this.FoodName = name;
            this.CategoryId = categoryId;
            this.Price = price;
        }

        // Hàm tạo từ DataRow
        public FoodBill(DataRow row)
        {
            FoodId = (int)row["FoodId"];
            FoodName = row["FoodName"].ToString();
            CategoryId = (int)row["CategoryId"];
            Price = (decimal)row["Price"];
       
        }
    }
}
