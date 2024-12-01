using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ValueObject
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int TableId { get; set; }
  
        public DateTime DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public int TrangThai { get; set; } // 1 là thanh toán, 0 là chưa thanh toán
   

        public Invoice() { }

        public Invoice(int invoiceId, int tableId, DateTime dateCheckIn, DateTime? dateCheckOut, int trangThai)
        {
            InvoiceId = invoiceId;
            TableId = tableId;
  
            DateCheckIn = dateCheckIn;
            DateCheckOut = dateCheckOut;
            TrangThai = trangThai;
           
        }

        public Invoice(DataRow row)
        {
            InvoiceId = (int)row["InvoiceId"];
            TableId = (int)row["TableId"];
            DateCheckIn = (DateTime)row["DateCheckIn"];
            var dateCheckOutTemp = row["DateCheckOut"];
            if (dateCheckOutTemp != DBNull.Value)
            {
                DateCheckOut = (DateTime?)dateCheckOutTemp;
            }
            else
            {
                DateCheckOut = null;
            }
            TrangThai = (int)row["TrangThai"];
           
        }

    }
}
