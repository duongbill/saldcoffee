using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int TableId { get; set; }
        public int AccountId { get; set; }
        public DateTime DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public int TrangThai { get; set; } // 1 là thanh toán, 0 là chưa thanh toán
        public decimal TotalPrice { get; set; }
    }
}
