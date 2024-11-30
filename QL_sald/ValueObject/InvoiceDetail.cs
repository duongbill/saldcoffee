using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ValueObject
{
    public class InvoiceDetail
    {
        public int InvoiceDetailId { get; set; }
        public int InvoiceId { get; set; }
        public int FoodId { get; set; }
        public int SoLuong { get; set; }
        public decimal Price { get; set; }

        // Hàm khởi tạo mặc định
        public InvoiceDetail() { }

        // Hàm khởi tạo với tham số
        public InvoiceDetail(int invoiceDetailId, int invoiceId, int foodId, int soLuong, decimal price)
        {
            InvoiceDetailId = invoiceDetailId;
            InvoiceId = invoiceId;
            FoodId = foodId;
            SoLuong = soLuong;
            Price = price;
        }

        // Hàm khởi tạo từ DataRow
        public InvoiceDetail(DataRow row)
        {
            InvoiceDetailId = (int)row["InvoiceDetailId"];
            InvoiceId = (int)row["InvoiceId"];
            FoodId = (int)row["FoodId"];
            SoLuong = (int)row["SoLuong"];
            Price = (decimal)row["Price"];
        }
    }
}
