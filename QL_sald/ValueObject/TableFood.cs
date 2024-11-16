using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class TableFood
    {
        public int TableId { get; set; }
        public string TableName { get; set; } = string.Empty; // Thêm string.Empty
        public string TrangThai { get; set; } = string.Empty; // Thêm string.Empty
    }

}
