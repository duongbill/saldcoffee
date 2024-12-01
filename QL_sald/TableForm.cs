using QL_sald.DataAccessLayer;
using QL_sald.logicLayer;
using QL_sald.ValueObject;
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
using ValueObject;

namespace QL_sald
{
    public partial class TableForm : Form
    {
        CategoriesLL categoriesLL = new CategoriesLL();
        FoodLL foodLL = new FoodLL();

        public TableForm()
        {
            InitializeComponent();
            // this.DoubleBuffered = true;

            LoadTable();
            LoadCategories();
        }

        void LoadCategories()
        {
            List<Category> categories = categoriesLL.GetAllCategories();
            cbCategories.DataSource = categories;
            cbCategories.DisplayMember = "CategoryName"; // Hi?n th? tên danh m?c
            cbCategories.ValueMember = "CategoryId"; // Giá tr? là ID c?a danh m?c
        }

        void GetFoodDataByCategoryID(int id)
        {
            List<FoodBill> listFood = foodLL.GetFoodDataByCategoryID(id);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "FoodName"; // Hi?n th? tên món an
            cbFood.ValueMember = "FoodId"; // Giá tr? là ID c?a món an
        }


        void LoadTable()
        {
            flpTable.Controls.Clear(); // Xóa các bàn cu (n?u có)
            List<TableFood> tableList = TableDAL.Instance.LoadTableList();
        

            foreach (TableFood table in tableList)
            {
                Button btn = new Button()
                {
                    Width = 120,
                    Height =120,
                    Text = table.TableName + Environment.NewLine + table.TrangThai,
                  
                    BackColor = table.TrangThai == "Bàn Trống" ? Color.Gray : Color.Pink,
                    Tag = table
                };

                btn.Click += btn_Click;
                flpTable.Controls.Add(btn);
            }
        }


        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<InvoiceShow> ListBillInfo = ShowInvoiceDAL.Instance.GetListShowInvoiceByTable(id);

            decimal totalPrice = 0;

            foreach (InvoiceShow item in ListBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            txtTotalPrice.Text = totalPrice.ToString("c", culture);
            LoadTable();
        }




        void btn_Click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            if (btn != null)
            {
                TableFood table = btn.Tag as TableFood;
                if (table != null)
                {
                    int tableId = table.TableId;
                    ShowBill(tableId);
                    lsvBill.Tag = table;

                    // Kích ho?t nút thêm món sau khi ch?n bàn
                    btn_them.Enabled = true;
                }
            }
        }


        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (cb != null && cb.SelectedItem != null)
            {
                Category selected = cb.SelectedItem as Category;
                if (selected != null)
                {
                    int id = selected.CategoryId;
                    GetFoodDataByCategoryID(id);
                }
            }
        }


        private void btn_them_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood;
            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm món.", "Thông báo");
                return;
            }

            int invoiceId = InvoiceDAL.Instance.GetUncheckInvoiceByTableID(table.TableId);

            FoodBill selectedFood = cbFood.SelectedItem as FoodBill;
            if (selectedFood == null)
            {
                MessageBox.Show("Vui lòng chọn đồ.", "Thông báo");
                return;
            }

            int foodId = selectedFood.FoodId;

            // Lấy số lượng từ cbCount (sẽ cho phép giá trị âm)
            int soluong = (int)cbCount.Value;

            if (invoiceId == -1) // Nếu chưa có hóa đơn
            {
                InvoiceDAL.Instance.InsertBill(table.TableId);
                int maxBill = InvoiceDAL.Instance.GetMaxBill();
                if (maxBill == -1)
                {
                    MessageBox.Show("Không thể tạo hóa đơn.", "Lỗi");
                    return;
                }
                InvoiceDetailDAL.Instance.InsertBillDetail(maxBill, foodId, soluong);
            }
            else // Nếu hóa đơn đã tồn tại
            {
                InvoiceDetailDAL.Instance.InsertBillDetail(invoiceId, foodId, soluong);
            }

            // Hiển thị lại hóa đơn sau khi thêm món
            ShowBill(table.TableId);
        }
        private void btn_thanhtoan_Click(object sender, EventArgs e)
        {
            TableFood table = lsvBill.Tag as TableFood;
            if (table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thanh toán.", "Thông báo");
                return;
            }

            int InvoiceId = InvoiceDAL.Instance.GetUncheckInvoiceByTableID(table.TableId);

            if (InvoiceId != -1)
            {
                if (MessageBox.Show("Bạn có muốn thanh toán hóa đơn cho bàn " + table.TableName + "?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    // Thanh toán hóa đơn và xóa dữ liệu hóa đơn
                    InvoiceDAL.Instance.CheckOut(InvoiceId);  // Cập nhật trạng thái hóa đơn
                    ShowBill(table.TableId);

                   
                    MessageBox.Show("Thanh toán thành công!", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Không có hóa đơn nào cần thanh toán cho bàn này.", "Thông báo");
            }
        }

       
          
        
    }
    
}