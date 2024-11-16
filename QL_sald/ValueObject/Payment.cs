using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; } = string.Empty; // Thêm string.Empty
        public int InvoiceId { get; set; }
    }

}
