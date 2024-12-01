using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QL_sald.compoment;
using QL_sald.logicLayer;
using ValueObject;

namespace QL_sald
{
    public partial class menu_cf : Form
    {
        private FoodLL foodLL;

        public menu_cf()
        {
            InitializeComponent();
            foodLL = new FoodLL();
            LoadFoodItems();
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
        }

        private void LoadFoodItems()
        {
            try
            {
                List<Food> foods = foodLL.GetFoodsByCategory(1); // CategoryId tương ứng

                flowLayoutPanel1.Padding = new Padding(20, 5, 5, 5);
                flowLayoutPanel1.AutoScroll = true;
                flowLayoutPanel1.Controls.Clear(); // Xóa các control hiện tại

                foreach (Food food in foods)
                {
                    FoodCPT foodCPT = new FoodCPT();
                    foodCPT.LoadData(food);
                    foodCPT.Margin = new Padding(0);
                    foodCPT.Width = 140;
                    foodCPT.Dock = DockStyle.None;

                    flowLayoutPanel1.Controls.Add(foodCPT);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }

        private void LoadCategoryItems(int categoryId, FlowLayoutPanel panel)
        {
            try
            {
                List<Food> foods = foodLL.GetFoodsByCategory(categoryId); // Sử dụng CategoryId tương ứng

                panel.Padding = new Padding(20, 10, 5, 5);
                panel.AutoScroll = true;
                panel.Controls.Clear(); // Xóa các control hiện tại

                foreach (Food food in foods)
                {
                    FoodCPT foodCPT = new FoodCPT();
                    foodCPT.LoadData(food);
                    foodCPT.Margin = new Padding(5); // Thêm khoảng cách giữa các item
                    foodCPT.Width = 140;
                    foodCPT.Height = 230;
                    foodCPT.Dock = DockStyle.None;

                    panel.Controls.Add(foodCPT);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}");
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                LoadCategoryItems(2, flowLayoutPanel2); // Sử dụng CategoryId của trà sữa là 2
            }
            else if (tabControl1.SelectedTab == tabPage3)
            {
                LoadCategoryItems(3, flowLayoutPanel3); // Đảm bảo flowLayoutPanel3 tồn tại trong tabPage3
            }
            else if (tabControl1.SelectedTab == tabPage4)
            {
                LoadCategoryItems(4, flowLayoutPanel4); // Đảm bảo flowLayoutPanel4 tồn tại trong tabPage4
            }
            else if (tabControl1.SelectedTab == tabPage5)
            {
                LoadCategoryItems(5, flowLayoutPanel5); // Đảm bảo flowLayoutPanel5 tồn tại trong tabPage5
            }
        }
    }
}
