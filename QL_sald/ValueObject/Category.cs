using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ValueObject
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        // Hàm khởi tạo mặc định
        public Category() { }

        // Hàm khởi tạo với tham số
        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        // Hàm khởi tạo từ DataRow
        public Category(DataRow row)
        {
            CategoryId = (int)row["CategoryId"];
            CategoryName = row["CategoryName"].ToString();
        }
    }
}
