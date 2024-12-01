using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ValueObject;

namespace QL_sald.compoment
{
    public partial class FoodCPT : UserControl
    {
        public FoodCPT()
        {
            InitializeComponent();
            this.Size = new Size(200, 150); // Đặt kích thước hợp lý cho từng FoodCPT
        }

        public void LoadData(Food food)
        {
            try
            {
                txtFoodName.Text = food.FoodName;
                txtPrice.Text = string.Format("{0:N2}đ", food.Price); // Định dạng giá trị tiền tệ với đơn vị "đ"

                // Lấy đường dẫn ảnh từ ImageURL
                string imagePath = Path.Combine(Application.StartupPath, food.ImageURL.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                Console.WriteLine($"Using image path: {imagePath}");

                if (File.Exists(imagePath))
                {
                    pic.Image = Image.FromFile(imagePath);
                }
                else
                {
                    LoadDefaultImage(); // Tải ảnh mặc định nếu không tìm thấy ảnh
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                LoadDefaultImage(); // Tải ảnh mặc định trong trường hợp xảy ra lỗi
            }
        }

        private void LoadDefaultImage()
        {
            pic.Image = Properties.Resources.bac_xiu;
        }

        
    }
}
