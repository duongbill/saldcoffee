using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QL_sald.compoment;
using QL_sald.logicLayer;
using ValueObject;

namespace QL_sald
{
    public partial class menu_cafe : Form
    {
        private FoodLL foodLL;

        public menu_cafe()
        {
            InitializeComponent();
            foodLL = new FoodLL();
            LoadFoodItems(); // Gọi hàm để tải dữ liệu
        }

        private void LoadFoodItems()
        {
            try
            {
                // Lấy danh sách món ăn từ database
                
               List<Food> foods = foodLL.GetFoodsByCategory(1); // Thay 1 bằng CategoryId tương ứng

                // Thiết lập padding và hướng sắp xếp cho FlowLayoutPanel
                flowLayoutPanel1.Padding = new Padding(10,10,10,10);
                flowLayoutPanel1.AutoScroll = true;
  

                // Duyệt qua danh sách món ăn và thêm vào FlowLayoutPanel
                foreach (Food food in foods)
                {
                    FoodCPT foodCPT = new FoodCPT();
                    foodCPT.LoadData(food); // Truyền dữ liệu món ăn vào FoodCPT

                    // Giảm khoảng cách giữa các FoodCPT bằng cách thiết lập Margin nhỏ hơn
                    foodCPT.Margin = new Padding(0);  // Giảm từ 5 xuống 2 (hoặc giá trị nhỏ hơn tùy ý)
                    foodCPT.Width = 150; // Điều chỉnh theo nhu cầu
                    foodCPT.Dock = DockStyle.None;

                    flowLayoutPanel1.Controls.Add(foodCPT);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
