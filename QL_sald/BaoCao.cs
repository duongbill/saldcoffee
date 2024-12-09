using QL_sald.DataAccessLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace QL_sald
{
    public partial class BaoCao : Form
    {
        public BaoCao()
        {
            InitializeComponent();
            LoadInvoice1List(); // Gọi khi khởi tạo form để hiển thị tất cả hóa đơn ban đầu
        }

        // Hàm tải danh sách hóa đơn từ bảng Invoice1
        void LoadInvoice1List()
        {
            string connectionString = @"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Invoice1"; // Truy vấn tất cả hóa đơn
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    dataGridViewInvoices.DataSource = data; // Hiển thị vào DataGridView

                    // Thiết lập tiêu đề cột
                    dataGridViewInvoices.Columns["TableId"].HeaderText = "Mã Bàn";
                    dataGridViewInvoices.Columns["DateCheckIn"].HeaderText = "Ngày Check-In";
                    dataGridViewInvoices.Columns["DateCheckOut"].HeaderText = "Ngày Check-Out";
                    dataGridViewInvoices.Columns["TrangThai"].HeaderText = "Trạng Thái";
                    dataGridViewInvoices.Columns["Total"].HeaderText = "Tổng Tiền";

                    // Tùy chỉnh thêm nếu cần
                    dataGridViewInvoices.Columns["Total"].DefaultCellStyle.Format = "C0"; // Định dạng tiền tệ cho cột Total
                    dataGridViewInvoices.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // Căn phải cho cột Total

                    // Tùy chỉnh màu sắc và font cho tiêu đề cột
                    dataGridViewInvoices.EnableHeadersVisualStyles = false;
                    dataGridViewInvoices.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue; // Màu nền của tiêu đề cột
                    dataGridViewInvoices.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black; // Màu chữ của tiêu đề cột
                    dataGridViewInvoices.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Font chữ của tiêu đề cột
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải danh sách hóa đơn: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {

           

            // Gọi lại hàm LoadInvoice1List để tải lại danh sách hóa đơn từ cơ sở dữ liệu
            LoadInvoice1List();
        }


        private void loadGetBillByDate(DateTime checkin, DateTime checkout)
        {
            string connectionString = @"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;";
            string query = "SELECT * FROM Invoice1 WHERE DateCheckIn >= @CheckIn AND DateCheckOut <= @CheckOut";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CheckIn", checkin);
                    command.Parameters.AddWithValue("@CheckOut", checkout);

                    // Debugging: Kiểm tra tham số trước khi thực thi
                    Console.WriteLine($"CheckIn: {checkin.ToString("yyyy-MM-dd")}, CheckOut: {checkout.ToString("yyyy-MM-dd")}");

                    DataTable data = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);

                    // Kiểm tra dữ liệu trả về
                    if (data.Rows.Count == 0)
                    {
                        MessageBox.Show("Không có dữ liệu hóa đơn trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    dataGridViewInvoices.DataSource = data; // Hiển thị vào DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa đơn theo thời gian: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sự kiện khi nhấn vào các ô trong DataGridView (nếu cần xử lý thêm)
        private void dataGridViewInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu cần thêm chức năng cho các cell của DataGridView, có thể xử lý ở đây
        }
    }
}


//private void LoadStatistics()
//{
//    try
//    {
//        // Lấy tổng hóa đơn và tổng doanh thu từ lớp InvoiceDAL
//        int totalInvoices = InvoiceDAL.Instance.GetTotalInvoices();
//        decimal totalRevenue = InvoiceDAL.Instance.GetTotalRevenue();
//        Staffdata staffdata = new Staffdata();
//        int totalStaff = staffdata.GetTotalEmployees();

//        // Sử dụng định dạng tiền tệ Việt Nam Đồng (₫)
//        CultureInfo vietnamCulture = new CultureInfo("vi-VN");

//        // Hiển thị dữ liệu lên các label
//        lblTotalInvoice.Text = $"{totalInvoices}";
//        lblTotalPrice.Text = $"{totalRevenue.ToString("C0", vietnamCulture)}"; // Định dạng tiền tệ
//        lblTotalStaff.Text = $"{totalStaff}";
//    }
//    catch (Exception ex)
//    {
//        // Hiển thị thông báo lỗi nếu có lỗi
//        MessageBox.Show($"Lỗi khi hiển thị thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }
//}
// Hàm tải danh sách hóa đơn theo khoảng thời gian