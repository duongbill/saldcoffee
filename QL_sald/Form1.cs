using System;
using System.Windows.Forms;

namespace QL_sald
{
    public partial class Form1 : Form
    {
      
        private menu_cafe menuControl = new menu_cafe();  // `menu_cafe` là Form con

        public Form1()
        {
            InitializeComponent();

            // Gán sự kiện Click cho btnMenu
            btnMenu.Click += new EventHandler(btnMenu_Click);

      
        }

        private Form currentFormChild;

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            childForm.TopLevel = false;                      // Đặt TopLevel là false để Form có thể được nhúng
            childForm.FormBorderStyle = FormBorderStyle.None; // Bỏ viền của Form con
            childForm.Dock = DockStyle.Fill;                 // Tùy chọn để Form con tự động giãn ra toàn bộ Panel
            panel_Body.Controls.Clear();                    // Xóa các điều khiển hiện tại trong Panel
            panel_Body.Controls.Add(childForm);             // Thêm Form con vào Panel
            panel_Body.Tag = childForm;                     // Đặt tag để tham chiếu Form con
            childForm.BringToFront();
            childForm.Show();                               // Hiển thị Form con
        }

        // Sự kiện Click cho nút btnMenu để hiển thị menuControl
        private void btnMenu_Click(object sender, EventArgs e)
        {
            OpenChildForm(menuControl); // Truyền Form con menuControl vào
        }

        // Sự kiện thoát ứng dụng
        private void btn_delete_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
