using QL_sald.DataAccessLayer;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace QL_sald
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
            LoadStatistics(); // Tải thống kê khi form được khởi tạo
        }

        private void LoadStatistics()
        {
            try
            {
                // Lấy tổng hóa đơn và tổng doanh thu từ lớp InvoiceDAL
                int totalInvoices = InvoiceDAL.Instance.GetTotalInvoices();
                decimal totalRevenue = InvoiceDAL.Instance.GetTotalRevenue();
                Staffdata staffdata = new Staffdata();
                int totalStaff = staffdata.GetTotalEmployees();

                // Sử dụng định dạng tiền tệ Việt Nam Đồng (₫)
                CultureInfo vietnamCulture = new CultureInfo("vi-VN");

                // Hiển thị dữ liệu lên các label
                lblTotalInvoice.Text = $"{totalInvoices}";
                lblTotalPrice.Text = $"{totalRevenue.ToString("C0", vietnamCulture)}"; // Định dạng tiền tệ
                lblTotalStaff.Text = $"{totalStaff}";
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi
                MessageBox.Show($"Lỗi khi hiển thị thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
