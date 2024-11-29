using QL_sald.DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QL_sald
{
    public partial class staff : Form
    {
        public staff()
        {
            InitializeComponent();
            displayStaffData();
        }

        // Hiển thị dữ liệu nhân viên trong DataGridView
        public void displayStaffData()
        {
            Staffdata data = new Staffdata();
            DataTable dataTable = data.sfData();
            viewStaff.DataSource = dataTable; // Gán DataTable cho DataSource của DataGridView
        }

        // hàm để lấy roleId từ roleName
        private int GetRoleIdByRoleName(string roleName)
        {
            int roleId = 0;  // Mặc định là 0 nếu không tìm thấy
            string connectionString = @"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;";  // Chuỗi kết nối

            string query = "SELECT RoleId FROM AccRole WHERE RoleName = @RoleName";  // Câu truy vấn SQL

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm tham số vào câu truy vấn
                    cmd.Parameters.AddWithValue("@RoleName", roleName);

                    try
                    {
                        conn.Open();  // Mở kết nối
                        var result = cmd.ExecuteScalar();  // Thực thi câu truy vấn và lấy kết quả
                        if (result != null)
                        {
                            roleId = Convert.ToInt32(result);  // Chuyển đổi kết quả sang int
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return roleId;  // Trả về RoleId (0 nếu không tìm thấy)
        }

        // Xử lý sự kiện Thêm nhân viên
        private void btn_add_Click(object sender, EventArgs e)
        {
            // Lấy RoleId từ tên Role (ví dụ: "Admin")
            int roleId = GetRoleIdByRoleName(txt_role.Text);  // txt_role.Text là tên vai trò từ textbox

            if (roleId > 0)
            {
                // Tiến hành thêm nhân viên vào cơ sở dữ liệu với roleId đã lấy
                string insertQuery = @"
                INSERT INTO Staff (FullName, Phone, DateOfBirth, Email, Gender, RoleId) 
                VALUES (@FullName, @Phone, @DateOfBirth, @Email, @Gender, @RoleId)";

                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@FullName", txt_name.Text);
                            cmd.Parameters.AddWithValue("@Phone", txt_phone.Text);
                            cmd.Parameters.AddWithValue("@DateOfBirth", dtpDateOfBirth.Value);
                            cmd.Parameters.AddWithValue("@Email", txt_email.Text);
                            cmd.Parameters.AddWithValue("@Gender", txt_sex.Text);
                            cmd.Parameters.AddWithValue("@RoleId", roleId);  // Gán RoleId đã lấy từ hàm

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayStaffData();  // Cập nhật lại DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Không thể thêm nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("RoleId không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_dlt_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một nhân viên trong DataGridView chưa
            if (viewStaff.SelectedRows.Count > 0)
            {
                // Lấy StaffId của nhân viên được chọn từ DataGridView
                int staffId = Convert.ToInt32(viewStaff.SelectedRows[0].Cells["StaffId"].Value);

                string deleteQuery = "DELETE FROM Staff WHERE StaffId = @StaffId";  // Câu truy vấn SQL để xóa nhân viên

                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                        {
                            // Thêm tham số StaffId vào câu truy vấn
                            cmd.Parameters.AddWithValue("@StaffId", staffId);

                            int rowsAffected = cmd.ExecuteNonQuery();  // Thực thi câu lệnh xóa

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Nhân viên đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayStaffData();  // Cập nhật lại DataGridView sau khi xóa
                            }
                            else
                            {
                                MessageBox.Show("Không thể xóa nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btn_update_Click(object sender, EventArgs e)
        {
            if (viewStaff.SelectedRows.Count > 0)
            {
                int staffId = Convert.ToInt32(viewStaff.SelectedRows[0].Cells["StaffId"].Value);
                string fullName = txt_name.Text;
                string phone = txt_phone.Text;
                DateTime dateOfBirth = dtpDateOfBirth.Value;
                string email = txt_email.Text;
                string gender = txt_sex.Text;
                int roleId = GetRoleIdByRoleName(txt_role.Text);

                if (roleId <= 0)
                {
                    MessageBox.Show("RoleId không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    MessageBox.Show("Địa chỉ email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!Regex.IsMatch(phone, @"^\d{10,15}$"))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string updateQuery = @"
                    UPDATE Staff 
                    SET FullName = @FullName, Phone = @Phone, DateOfBirth = @DateOfBirth, 
                        Email = @Email, Gender = @Gender, RoleId = @RoleId
                    WHERE StaffId = @StaffId";

                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;"))
                    {
                        await conn.OpenAsync();
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@StaffId", staffId);
                            cmd.Parameters.AddWithValue("@FullName", fullName);
                            cmd.Parameters.AddWithValue("@Phone", phone);
                            cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@Gender", gender);
                            cmd.Parameters.AddWithValue("@RoleId", roleId);

                            int rowsAffected = await cmd.ExecuteNonQueryAsync();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                displayStaffData();
                            }
                            else
                            {
                                MessageBox.Show("Không thể cập nhật thông tin nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
