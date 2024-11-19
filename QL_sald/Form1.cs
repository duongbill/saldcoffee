using System;
using System.Windows.Forms;

namespace QL_sald
{
    public partial class Form1 : Form
    {
      
        private menu_cafe menuControl = new menu_cafe();  // `menu_cafe` là Form con
        private Cài_đặt stControl = new Cài_đặt();
        private TrangChu tcControl = new TrangChu();
        private packages pgControl = new packages();
        private staff sfControl = new staff();
        public Form1()
        {
            InitializeComponent();

            // Gán sự kiện Click cho btnMenu
            btnMenu.Click += new EventHandler(btnMenu_Click);
            // Gán sự kiện đăng xuất cho `Cài_đặt`
            stControl.LogoutRequested += OnLogoutRequested;

        }

        private Form currentFormChild;
        private UserControl currentUserControlChild;

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

        private void OpenChildControl(UserControl childControl)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentUserControlChild = childControl;
      
            childControl.Dock = DockStyle.Fill;                 // Tùy chọn để Form con tự động giãn ra toàn bộ Panel
            panel_Body.Controls.Clear();                    // Xóa các điều khiển hiện tại trong Panel
            panel_Body.Controls.Add(childControl);             // Thêm Form con vào Panel
            panel_Body.Tag = childControl;                     // Đặt tag để tham chiếu Form con
            childControl.BringToFront();
            childControl.Show();                               // Hiển thị Form con
        }
        // Phương thức xử lý sự kiện đăng xuất
        private void OnLogoutRequested(object sender, EventArgs e)
        {
            // Đóng form chính và mở lại form đăng nhập
            this.Hide();
        }

        // Sự kiện Click cho nút btnMenu để hiển thị menuControl
        private void btnMenu_Click(object sender, EventArgs e)
        {
         menu_cafe menuControl1 = new menu_cafe();
        OpenChildForm(menuControl1); // Truyền Form con menuControl vào

        }

        // Sự kiện thoát ứng dụng
        private void btn_delete_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ct_Click(object sender, EventArgs e)
        {
            OpenChildControl(stControl); // Truyền Form con menuControl vào

        }

        private void btn_tc_Click(object sender, EventArgs e)
        {
            TrangChu tcControl = new TrangChu();
            OpenChildForm(tcControl); // Truyền Form con menuControl vào
        }

        private void btn_dh_Click(object sender, EventArgs e)
        {
            OpenChildControl(pgControl);
        }

        private void btn_nv_Click(object sender, EventArgs e)
        {
            staff sfControl = new staff();
            OpenChildForm(sfControl); // Truyền Form con menuControl vào
        }
    }
}
