using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class FoodIngredient
    {
        public int FoodIngredientId { get; set; }
        public int FoodId { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; } // Số lượng nguyên liệu cho món ăn này
    }
}
