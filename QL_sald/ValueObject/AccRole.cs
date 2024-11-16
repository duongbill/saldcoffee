using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class AccRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty; // Thêm string.Empty
    }
}
