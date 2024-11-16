using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; } = string.Empty; // Thêm string.Empty
        public int CategoryId { get; set; }
        public int IngredientId { get; set; }
        public decimal Price { get; set; }
    }

}
