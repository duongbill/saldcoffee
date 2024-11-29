using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_sald.table

{
    public class TableFood
    {
        public int TableId { get; set; }
        public string TableName { get; set; } = string.Empty; // Đảm bảo TableName không null
        public string TrangThai { get; set; } = string.Empty; // Đảm bảo TrangThai không null

        // Constructor mặc định
        public TableFood() { }

        // Constructor có tham số với kiểm tra tính hợp lệ
        public TableFood(int tableId, string tableName, string trangThai)
        {
            

            TableId = tableId;
            TableName = tableName;
            TrangThai = trangThai;
        }
    }
}
