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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Server=localhost,1433;Database=quanly_cafe;User Id=sa;Password=123456;");
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
                        MessageBox.Show("Đăng nhập thành công!");
                      
                        this.Close();
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
    }
}
