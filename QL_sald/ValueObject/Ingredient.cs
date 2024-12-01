using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; } = string.Empty; // Thêm string.Empty
        public int SoLuong { get; set; }
        public string ImageURL { get; set; } = string.Empty; // Cũng nên có giá trị mặc định
        public DateTime LastUpdated { get; set; }
    }

}
