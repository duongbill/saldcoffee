using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FullName { get; set; } = string.Empty; // Thêm string.Empty
        public string Phone { get; set; } = string.Empty; // Thêm string.Empty
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty; // Thêm string.Empty
        public bool Gender { get; set; }
        public int AccountId { get; set; }
        public int RoleId { get; set; }
    }
}
