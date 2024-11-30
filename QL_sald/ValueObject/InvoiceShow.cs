using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_sald.ValueObject
{
    public class InvoiceShow
    {
        // Các thuộc tính
        public string FoodName { get; set; }
        public int SoLuong { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        // Hàm khởi tạo mặc định
        public InvoiceShow() { }

        // Hàm khởi tạo với tham số
        public InvoiceShow(string foodName, int soLuong, decimal price, decimal ttprice = 0)
        {
            FoodName = foodName;
            SoLuong = soLuong;
            Price = price;
            TotalPrice = ttprice;
        }

        // Hàm khởi tạo từ DataRow
        public InvoiceShow(DataRow row)
        {
            FoodName = row["FoodName"].ToString();
            SoLuong = (int)row["SoLuong"];
            Price = (decimal)row["Price"];
            TotalPrice = (decimal)row["TotalPrice"];
        }

        // Tính tổng giá trị
        
    }
}
