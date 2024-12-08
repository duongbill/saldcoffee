using System;

namespace ValueObject
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = string.Empty; // Thêm string.Empty
        public int SoLuong { get; set; }
        public string ImageURL { get; set; } = string.Empty; // Cũng nên có giá trị mặc định
        public DateTime LastUpdated { get; set; }

        // Hàm khởi tạo không tham số
        public Ingredient()
        {
            LastUpdated = DateTime.Now;
        }

        // Hàm khởi tạo có tham số
        public Ingredient(int ingredientId, string ingredientName, int soLuong, string imageURL)
        {
            IngredientId = ingredientId;
            IngredientName = ingredientName;
            SoLuong = soLuong;
            ImageURL = imageURL;
            LastUpdated = DateTime.Now;
        }
    }
}
