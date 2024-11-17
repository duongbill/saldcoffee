using System;
using System.Windows.Forms;

namespace QL_sald
{
    public partial class Cài_đặt : UserControl
    {
        public event EventHandler LogoutRequested;

        public Cài_đặt()
        {
            InitializeComponent();
          
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Bạn muốn đăng xuất?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                LogoutRequested?.Invoke(this, EventArgs.Empty);
            }
            SignIn si = new SignIn();
            si.Show();
        }
    }
}

