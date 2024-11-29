using System;
using System.Windows.Forms;

namespace QL_sald.table
{
    public partial class TableInfoControl : UserControl
    {
        public TableInfoControl()
        {
            InitializeComponent();  // Khởi tạo các điều khiển
        }

        // Các thuộc tính để truy cập và thay đổi thông tin trong UserControl
        public string TableName
        {
            get { return labelTableName.Text; }
            set { labelTableName.Text = value; }
        }

        public string TrangThai
        {
            get { return labelTrangThai.Text; }
            set { labelTrangThai.Text = value; }
        }

       
        private void TableInfoControl_Load(object sender, EventArgs e)
        {
            // Xử lý khi load UserControl
        }

        private void labelTrangThai_Click(object sender, EventArgs e)
        {

        }

        private void labelTableName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
