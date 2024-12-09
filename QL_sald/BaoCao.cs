
﻿using QL_sald.DataAccessLayer;
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
            InvoiceDAL invoice = new InvoiceDAL();
            DataTable dataTable = invoice.GetListInvoiceByDate(checkIn,checkOut);

            viewInvoice.DataSource = dataTable; // Gán dữ liệu vào DataGridView
        }
        public void displayStaffData()
        {
            Staffdata data = new Staffdata();
            DataTable dataTable = data.sfData();
            viewInvoice.DataSource = dataTable; // Gán DataTable cho DataSource của DataGridView
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            loadListViewByDate(checkInDate.Value, checkOutDate.Value);
        }
    }
}

