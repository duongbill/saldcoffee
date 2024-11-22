using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QL_sald.DataAccessLayer;

namespace QL_sald
{
    public partial class food : UserControl
    {
        private FoodData foodData;

        public food()
        {
            InitializeComponent();
            foodData = new FoodData();
            LoadFoodItems();
        }

        private void LoadFoodItems()
        {
            DataTable foodTable = foodData.GetFoodData();

            foreach (DataRow row in foodTable.Rows)
            {
                Panel foodPanel = new Panel
                {
                    Size = new Size(200, 300),
                    Margin = new Padding(10)
                };

                // Load tên món ăn
                Label lblFoodName = new Label
                {
                    Text = row["FoodName"].ToString(),
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // Load giá
                Label lblPrice = new Label
                {
                    Text = $"{row["Price"]:C0}", // Format kiểu tiền tệ
                    Font = new Font("Arial", 10, FontStyle.Regular),
                    Dock = DockStyle.Bottom,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                // Load ảnh món ăn
                PictureBox pbFoodImage = new PictureBox
                {
                    Size = new Size(180, 180),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Image = LoadImageFromPath(row["ImageURL"].ToString())
                };

                // Thêm các thành phần vào Panel
                foodPanel.Controls.Add(lblFoodName);
                foodPanel.Controls.Add(pbFoodImage);
                foodPanel.Controls.Add(lblPrice);

                // Thêm Panel vào FlowLayoutPanel (flowLayoutPanelFoodItems là FlowLayoutPanel trong giao diện)
                flowLayoutPanelFoodItems.Controls.Add(foodPanel);
            }
        }

        private Image LoadImageFromPath(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                return Image.FromFile(imagePath);
            }
            else
            {
                return Image.FromFile(imagePath);

            }
        }
    }
}
