using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_sald.ValueObject
{
    public class TableFood
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public string TrangThai { get; set; }

        public TableFood() { }

        public TableFood(int tableId, string tableName, string trangThai)
        {
            TableId = tableId;
            TableName = tableName;
            TrangThai = trangThai;
        }

        public TableFood(DataRow row)
        {
            TableId = (int)row["tableId"];
            TableName = row["tableName"].ToString();
            TrangThai = row["trangThai"].ToString();
        }
    }
}

