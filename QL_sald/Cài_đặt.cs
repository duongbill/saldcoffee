using System;
using System.Windows.Forms;

namespace QL_sald
{
    public partial class Cài_đặt : UserControl
    {
        public event EventHandler LogoutRequested;
        private Form mainForm;

        public Cài_đặt(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn muốn đăng xuất?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                LogoutRequested?.Invoke(this, EventArgs.Empty);

                // Hiển thị form đăng nhập
                SignIn si = new SignIn();
                si.Show();

                // Đóng form chính
                mainForm.Close();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng chưa khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Tính năng chưa khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
