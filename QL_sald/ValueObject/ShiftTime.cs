using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class ShiftTime
    {
        public int ShiftId { get; set; }
        public int StaffId { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
    }
}
