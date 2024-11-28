using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QL_sald.logicLayer;
using ValueObject;

namespace QL_sald.compoment
{
    public partial class FoodCPT : UserControl
    {
        private FoodLL foodLL;
        private readonly string defaultImagePath = "path_to_default_image\\default.png"; // Đường dẫn ảnh mặc định

        public FoodCPT()
        {
            InitializeComponent();
            foodLL = new FoodLL();
            LoadData(1); // Thay 1 bằng CategoryId tương ứng
        }

        private void LoadData(int categoryId)
        {
            try
            {
                var foods = foodLL.GetFoodsByCategory(categoryId);
                Console.WriteLine($"Foods count: {foods.Count}");

                if (foods.Count > 0)
                {
                    Food selectedFood = foods[0];
                    txtFoodName.Text = selectedFood.FoodName;
                    txtPrice.Text = selectedFood.Price.ToString("C");

                    if (!string.IsNullOrEmpty(selectedFood.ImageURL) && File.Exists(selectedFood.ImageURL))
                    {
                        pic.Image = Image.FromFile(selectedFood.ImageURL);
                    }
                    else
                    {
                        LoadDefaultImage(); // Luôn tải ảnh mặc định khi không tìm thấy ảnh hoặc URL rỗng
                    }
                }
                else
                {
                    LoadDefaultImage(); // Tải ảnh mặc định khi danh mục không có dữ liệu
                }
            }
            catch (Exception ex)
            {
                // Chỉ ghi log, không hiển thị thông báo lỗi
                Console.WriteLine($"Error: {ex}");
                LoadDefaultImage(); // Tải ảnh mặc định trong trường hợp xảy ra lỗi
            }
        }

        private void LoadDefaultImage()
        {
            if (File.Exists(defaultImagePath))
            {
                pic.Image = Image.FromFile(defaultImagePath);
            }
            else
            {
                
                pic.Image = pic.Image = Properties.Resources.bac_xiu; 
            
            }
        }

        private void txtFoodName_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện click vào tên món ăn (nếu cần)
        }
    }
}
