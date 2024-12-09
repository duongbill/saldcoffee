using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueObject;


namespace QL_sald
{
    public partial class Ingredient1 : Form
    {
        public Ingredient1()
        {
            InitializeComponent();
            LoadIngredientList();
            AddIngredientBinding();
        }

        private void txttim_TextChanged(object sender, EventArgs e)
        {
            string keyword = txttim.Text.Trim();
            SearchIngredient(keyword);
        }

        void SearchIngredient(string keyword)
        {
            string connectionString = @"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;";
            SqlConnection connection = new SqlConnection(connectionString);

            // Nếu từ khóa rỗng, trả về toàn bộ danh sách nguyên liệu
            string query = string.IsNullOrWhiteSpace(keyword)
                ? "SELECT * FROM Ingredient"
                : "SELECT * FROM Ingredient WHERE IngredientName LIKE @Keyword";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                // Thêm tham số từ khóa nếu không rỗng
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                }

                DataTable data = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
                connection.Close();

                // Cập nhật dữ liệu vào DataGridView
                viewIngredient.DataSource = data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void LoadIngredientList()
        {
            string connectionString = @"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Ingredient";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            viewIngredient.DataSource = data;
        }

        void AddIngredientBinding()
        {
            guna2TextBoxid.DataBindings.Add(new Binding("Text", viewIngredient.DataSource, "IngredientId"));
            guna2TextBoxten.DataBindings.Add(new Binding("Text", viewIngredient.DataSource, "IngredientName"));
            guna2TextBoxsoluong.DataBindings.Add(new Binding("Text", viewIngredient.DataSource, "SoLuong"));
            guna2TextBoxphanloai.DataBindings.Add(new Binding("Text", viewIngredient.DataSource, "PhanLoai"));
            dtpDate.DataBindings.Add(new Binding("Text", viewIngredient.DataSource, "LastUpdated"));
            guna2TextBoxanh.DataBindings.Add(new Binding("Text", viewIngredient.DataSource, "ImageURL"));
        }
        private void btn_anh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                guna2TextBoxanh.Text = ofd.FileName; // Hiển thị đường dẫn ảnh được chọn
            }
        }
       
        // Xử lý sự kiện Thêm nguyên liệu
        private void btn_them_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin nhập vào có hợp lệ hay không
            if (!string.IsNullOrEmpty(guna2TextBoxten.Text) &&
                !string.IsNullOrEmpty(guna2TextBoxsoluong.Text) &&
                !string.IsNullOrEmpty(guna2TextBoxphanloai.Text))
            {
                // Tiến hành thêm nguyên liệu vào cơ sở dữ liệu
                    string insertQuery = @"
            INSERT INTO Ingredient (IngredientName, SoLuong, PhanLoai, LastUpdated, ImageURL) 
            VALUES (@IngredientName, @SoLuong, @PhanLoai, @LastUpdated, @ImageURL)";

                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@IngredientName", guna2TextBoxten.Text);  // Tên nguyên liệu
                            cmd.Parameters.AddWithValue("@SoLuong", guna2TextBoxsoluong.Text);  // Số lượng
                            cmd.Parameters.AddWithValue("@PhanLoai", guna2TextBoxphanloai.Text);  // Phân loại
                            cmd.Parameters.AddWithValue("@LastUpdated", DateTime.Now);  // Cập nhật thời gian hiện tại
                            cmd.Parameters.AddWithValue("@ImageURL", guna2TextBoxanh.Text);  // Đường dẫn ảnh

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thêm nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadIngredientList();  // Cập nhật lại DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Không thể thêm nguyên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Vui lòng điền đầy đủ thông tin nguyên liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // Xử lý sự kiện Xóa nguyên liệu
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một nguyên liệu trong DataGridView chưa
            if (viewIngredient.SelectedRows.Count > 0)
            {
                // Lấy IngredientId của nguyên liệu được chọn từ DataGridView
                int ingredientId = Convert.ToInt32(viewIngredient.SelectedRows[0].Cells["IngredientId"].Value);

                string deleteQuery = "DELETE FROM Ingredient WHERE IngredientId = @IngredientId";  // Câu truy vấn SQL để xóa nguyên liệu

                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;"))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                        {
                            // Thêm tham số IngredientId vào câu truy vấn
                            cmd.Parameters.AddWithValue("@IngredientId", ingredientId);

                            int rowsAffected = cmd.ExecuteNonQuery();  // Thực thi câu lệnh xóa

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Nguyên liệu đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadIngredientList();  // Cập nhật lại DataGridView sau khi xóa
                            }
                            else
                            {
                                MessageBox.Show("Không thể xóa nguyên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Vui lòng chọn một nguyên liệu để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private async void btn_sua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một nguyên liệu trong DataGridView chưa
            if (viewIngredient.SelectedRows.Count > 0)
            {
                // Lấy IngredientId của nguyên liệu được chọn từ DataGridView
                int ingredientId = Convert.ToInt32(viewIngredient.SelectedRows[0].Cells["IngredientId"].Value);
                string ingredientName = guna2TextBoxten.Text;
                string quantity = guna2TextBoxsoluong.Text;
                string category = guna2TextBoxphanloai.Text;
                string imageUrl = guna2TextBoxanh.Text;
                DateTime lastUpdated = dtpDate.Value;

                // Kiểm tra nếu có trường nào còn trống
                if (string.IsNullOrWhiteSpace(ingredientName) || string.IsNullOrWhiteSpace(quantity) || string.IsNullOrWhiteSpace(category))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

               

                string updateQuery = @"
                UPDATE Ingredient 
                SET IngredientName = @IngredientName, SoLuong = @SoLuong, PhanLoai = @PhanLoai, 
                    LastUpdated = @LastUpdated, ImageURL = @ImageURL
                WHERE IngredientId = @IngredientId";

                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;"))
                    {
                        await conn.OpenAsync();
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@IngredientId", ingredientId);
                            cmd.Parameters.AddWithValue("@IngredientName", ingredientName);
                            cmd.Parameters.AddWithValue("@SoLuong", quantity);
                            cmd.Parameters.AddWithValue("@PhanLoai", category);
                            cmd.Parameters.AddWithValue("@LastUpdated", lastUpdated);
                            cmd.Parameters.AddWithValue("@ImageURL", imageUrl);

                            int rowsAffected = await cmd.ExecuteNonQueryAsync();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cập nhật thông tin nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadIngredientList();  // Cập nhật lại DataGridView sau khi sửa
                            }
                            else
                            {
                                MessageBox.Show("Không thể cập nhật thông tin nguyên liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Vui lòng chọn một nguyên liệu để sửa thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }





        // Các sự kiện khác (không sử dụng trong đoạn mã hiện tại)
        private void tim_Click(object sender, EventArgs e)
        {

        }
        private void guna2HtmlLabel1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void viewStaff_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e) { }
        private void guna2TextBoxten_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBoxid_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBoxgia_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBoxanh_TextChanged(object sender, EventArgs e) { }

       
    }
}
