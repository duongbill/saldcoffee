using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty; // Thêm string.Empty
    }

}
