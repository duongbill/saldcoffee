using System;

namespace ValueObject
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; } = string.Empty; // Tránh null reference
        public int CategoryId { get; set; }
        public int IngredientId { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; } = string.Empty; // Cũng nên có default value

    }
}
