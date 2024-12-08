using QL_sald.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_sald
{
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
            LoadStatistics();
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
        // Hàm tải danh sách hóa đơn theo khoảng thời gian
        void loadListViewByDate(DateTime checkIn, DateTime checkOut)
        {
            // Lấy dữ liệu từ InvoiceDAL
            DataTable data = InvoiceDAL.Instance.GetListInvoiceByDate(checkIn, checkOut);

            // Xóa các mục cũ trong FlowLayoutPanel
            flpTable.Controls.Clear();

            // Lặp qua từng dòng trong DataTable để hiển thị trên UI
            foreach (DataRow row in data.Rows)
            {
                // Tạo một panel hoặc label để hiển thị dữ liệu
                Panel panel = new Panel();
                panel.Width = flpTable.Width - 20; // Set chiều rộng panel
                panel.Height = 30; // Set chiều cao panel
                panel.Padding = new Padding(5);

                // Tạo các Label cho các cột
                Label lblInvoiceId = new Label { Text = $"Invoice ID: {row["InvoiceId"]}", AutoSize = true };
                Label lblTableId = new Label { Text = $"Table ID: {row["TableId"]}", AutoSize = true };
                Label lblDate = new Label { Text = $"Date: {Convert.ToDateTime(row["InvoiceDate"]).ToString("dd/MM/yyyy")}", AutoSize = true };
                Label lblTotalPrice = new Label { Text = $"Total Price: {Convert.ToDecimal(row["TotalPrice"]).ToString("C0", new CultureInfo("vi-VN"))}", AutoSize = true };

                // Thêm các label vào panel
                panel.Controls.Add(lblInvoiceId);
                panel.Controls.Add(lblTableId);
                panel.Controls.Add(lblDate);
                panel.Controls.Add(lblTotalPrice);

                // Thêm panel vào FlowLayoutPanel
                flpTable.Controls.Add(panel);
            }
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            loadListViewByDate(checkInDate.Value, checkOutDate.Value);
        }
    }
}
