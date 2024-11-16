using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class Order
    {
        public int OrderId { get; set; }
        public int InvoiceDetailId { get; set; }
        public string Status { get; set; } = string.Empty; // Thêm string.Empty
    }
}
