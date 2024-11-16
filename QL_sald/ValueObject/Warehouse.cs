using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public int IngredientId { get; set; }
        public int SoLuong { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
