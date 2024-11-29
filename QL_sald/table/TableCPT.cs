using System;
using System.Data;
using System.Windows.Forms;

namespace QL_sald.table
{
    public partial class TableCPT : UserControl
    {
        private TableFoodLL tableFoodLL; // Khai báo đối tượng để truy cập logic lớp

        public TableCPT()
        {
            InitializeComponent();
            tableFoodLL = new TableFoodLL(); // Khởi tạo đối tượng TableFoodLL
        }

        // Phương thức để truyền dữ liệu vào và thay thế nội dung của label_ban và label_tt
        public void LoadData(int tableId)
        {
            // Lấy dữ liệu từ cơ sở dữ liệu
            DataTable dt = tableFoodLL.GetTableDetails(tableId);

            // Kiểm tra nếu có dữ liệu trả về
            if (dt.Rows.Count > 0)
            {
                // Lấy tên bàn và trạng thái từ DataTable
                string tableName = dt.Rows[0]["TableName"].ToString();
                string trangThai = dt.Rows[0]["TrangThai"].ToString();

                // Truyền dữ liệu vào các label
                label_ban.Text = tableName;
                label_tt.Text = trangThai;

            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin về bàn này.");
            }
        }
    }
}
