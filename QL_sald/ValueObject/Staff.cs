using System;
using System.Collections.Generic;
using System.Text;

namespace ValueObject
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FullName { get; set; } = string.Empty; // Đặt giá trị mặc định là chuỗi rỗng
        public string Phone { get; set; } = string.Empty; // Đặt giá trị mặc định là chuỗi rỗng
        public DateTime? DateOfBirth { get; set; } // Sử dụng DateTime? cho các giá trị NULL
        public string Email { get; set; } = string.Empty; // Đặt giá trị mặc định là chuỗi rỗng
        public string Sex { get; set; } = string.Empty; // Đặt giá trị mặc định là chuỗi rỗng
        public int AccountId { get; set; }
        public int RoleId { get; set; }


    }
}
    

