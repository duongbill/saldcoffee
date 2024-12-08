using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ValueObject;

namespace QL_sald.compoment
{
    public partial class IngreCPT : UserControl
    {
        public IngreCPT()
        {
            InitializeComponent();
            this.Size = new Size(220, 150); // Đặt kích thước hợp lý cho từng IngreCPT
        }

        public void LoadData(Ingredient ingredient)
        {
            try
            {
                // Kiểm tra nếu các control đã được khởi tạo
                if (txtIngredientName != null && txtQuantity != null && pic != null)
                {
                    txtIngredientName.Text = ingredient.IngredientName;
                    txtQuantity.Text = ingredient.SoLuong.ToString(); // Display quantity

                    // Construct the image path
                    string imagePath = Path.Combine(Application.StartupPath, ingredient.ImageURL.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                    Console.WriteLine($"Using image path: {imagePath}");

                    if (File.Exists(imagePath))
                    {
                        pic.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        Console.WriteLine("Image file not found, loading default image.");
                        LoadDefaultImage(); // Load default image if not found
                    }
                }
                else
                {
                    Console.WriteLine("One or more controls are not initialized.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}");
                LoadDefaultImage(); // Load default image in case of error
            }
        }

        private void LoadDefaultImage()
        {
            //
        }

        private void pic_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantity_Click(object sender, EventArgs e)
        {

        }

        private void txtIngredientName_Click(object sender, EventArgs e)
        {

        }
    }
}
