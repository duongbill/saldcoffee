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
        }

        private void LoadFoodItems()
        {
            try
            {
                List<Food> foods = foodLL.GetFoodsByCategory(1); // Replace 1 with the actual category ID

                flowLayoutPanel1.Padding = new Padding(20, 5, 5, 5);
                flowLayoutPanel1.AutoScroll = true;
                flowLayoutPanel1.Controls.Clear(); // Clear existing controls

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

        private void btn_them_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
            LoadFoodItems(); // Reload data after closing AddProductForm
        }
    }
}
