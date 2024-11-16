using System;
using System.Collections.Generic;
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
    }

}
