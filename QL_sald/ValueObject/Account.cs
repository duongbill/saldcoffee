using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class Account
    {
        public int AccountId { get; set; }
        public string DisplayName { get; set; } = string.Empty; // Thêm string.Empty
        public string UserName { get; set; } = string.Empty; // Thêm string.Empty
        public string PassWord { get; set; } = string.Empty; // Thêm string.Empty
        public string RoleName { get; set; } = string.Empty; // Thêm string.Empty
    }

}
