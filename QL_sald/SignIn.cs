using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_sald
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;");
                {
                    conn.Open();
                    string tk = txtTaiKhoan.Text;
                    string mk = txtMatKhau.Text;
                    string sql = "select * from Account where UserName=@UserName and PassWord=@PassWord";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@UserName", tk);
                    cmd.Parameters.AddWithValue("@PassWord", mk);
                    SqlDataReader dta = cmd.ExecuteReader();

                    if (dta.Read())
                    {
                       

                        
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide(); 
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại tài khoản và mật khẩu.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }


        private void passhide_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = passhide.Checked ? '\0' : '*';
        }

       
    }
}
