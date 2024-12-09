using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ValueObject;
using QL_sald.logicLayer;
using DataAcessLayer;
using System.Data;
using Microsoft.Data.SqlClient;


namespace QL_sald
{
    public partial class AddProductForm : Form
    {
        private FoodLL foodLL;
        private CategoriesLL categoriesLL;
        private IngredientsLL ingredientsLL;

        public AddProductForm()
        {
            InitializeComponent();
            foodLL = new FoodLL();
            categoriesLL = new CategoriesLL();
            ingredientsLL = new IngredientsLL();
            LoadCategories();
            LoadIngredients();
            LoadFoodItems(); // Add this method call
        }

        private void LoadCategories()
        {
            List<Category> categories = categoriesLL.GetAllCategories();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";
        }

        private void LoadIngredients()
        {
            List<Ingredient> ingredients = ingredientsLL.GetAllIngredients();
            cmbIngredient.DataSource = ingredients;
            cmbIngredient.DisplayMember = "IngredientName";
            cmbIngredient.ValueMember = "IngredientId";
        }

        private void LoadFoodItems()
        {
            List<Food> foods = foodLL.GetAllFoods(); 
            guna2DataGridView1.DataSource = foods; 
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtImageURL.Text = ofd.FileName;
            }
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = @"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;";
            string query = @"
            INSERT INTO Food (FoodName, CategoryId, IngredientId, Price, ImageURL)
            VALUES (@FoodName, @CategoryId, @IngredientId, @Price, @ImageURL)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FoodName", txtFoodName.Text.Trim());
                        cmd.Parameters.AddWithValue("@CategoryId", Convert.ToInt32(cmbCategory.SelectedValue));
                        cmd.Parameters.AddWithValue("@IngredientId", Convert.ToInt32(cmbIngredient.SelectedValue));
                        cmd.Parameters.AddWithValue("@Price", txtPrice.Text.Trim());
                        cmd.Parameters.AddWithValue("@ImageURL", txtImageURL.Text.Trim());

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadFoodItems(); // Cập nhật danh sách sản phẩm
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChooseImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtImageURL.Text = ofd.FileName; // Hiển thị đường dẫn ảnh được chọn
            }
        }

       
            private void btnDel_Click(object sender, EventArgs e)
            {
                ConnectSQL connectSQL = new ConnectSQL();
                if (guna2DataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    foreach (DataGridViewRow row in guna2DataGridView1.SelectedRows)
                    {
                        int foodId = (int)row.Cells["FoodId"].Value; // Lấy giá trị FoodId từ cột tương ứng

                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@FoodId", foodId)
                        };

                        int rowsAffected = connectSQL.ExecuteSQL("DeleteFoodById", parameters); // Sử dụng stored procedure DeleteFoodById

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    // Cập nhật lại giao diện sau khi xóa
                    LoadFoodItems();
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("REFERENCE"))
                    {
                        MessageBox.Show("Không thể xóa sản phẩm vì nó đang được sử dụng trong hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }



        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedFoodId = Convert.ToInt32(guna2DataGridView1.SelectedRows[0].Cells["FoodId"].Value);
            string connectionString = @"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;";
            string queryUpdate = @"
            UPDATE Food
            SET FoodName = @FoodName, 
                CategoryId = @CategoryId, 
                IngredientId = @IngredientId, 
                Price = @Price, 
                ImageURL = @ImageURL
            WHERE FoodId = @FoodId";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(queryUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@FoodName", txtFoodName.Text.Trim());
                        cmd.Parameters.AddWithValue("@CategoryId", Convert.ToInt32(cmbCategory.SelectedValue));
                        cmd.Parameters.AddWithValue("@IngredientId", Convert.ToInt32(cmbIngredient.SelectedValue));
                        cmd.Parameters.AddWithValue("@Price", txtPrice.Text.Trim());
                        cmd.Parameters.AddWithValue("@ImageURL", txtImageURL.Text.Trim());
                        cmd.Parameters.AddWithValue("@FoodId", selectedFoodId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadFoodItems(); // Cập nhật danh sách sản phẩm
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getInfo(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra chỉ số dòng hợp lệ
                if (e.RowIndex >= 0 && guna2DataGridView1.Rows[e.RowIndex].Cells["FoodId"].Value != null)
                {
                    // Lấy hàng được chọn
                    DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];

                    // Gán dữ liệu từ các cột vào các ô nhập liệu
                    txtFoodName.Text = selectedRow.Cells["FoodName"].Value?.ToString();
                    cmbCategory.SelectedValue = Convert.ToInt32(selectedRow.Cells["CategoryId"].Value);
                    cmbIngredient.SelectedValue = Convert.ToInt32(selectedRow.Cells["IngredientId"].Value);
                    txtImageURL.Text = selectedRow.Cells["ImageURL"].Value?.ToString();
                    txtPrice.Text = selectedRow.Cells["Price"].Value?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lấy thông tin sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImageURL_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
