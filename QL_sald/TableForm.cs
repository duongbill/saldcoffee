using QL_sald.DataAccessLayer;
using QL_sald.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueObject;

namespace QL_sald
{
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
            // this.DoubleBuffered = true; 

            LoadTable();
        }

        void LoadTable()
        {
            List<TableFood> tableList = TableDAL.Instance.LoadTableList();

            foreach (TableFood table in tableList)
            {
                Button btn = new Button() { Width = TableDAL.TableWidth, Height = TableDAL.TableHeight };
                btn.Text= table.TableName + Environment.NewLine  + table.TrangThai;
                btn.Click += btn_Click;
                btn.Tag= table;
                switch(table.TrangThai)
                {
                    case "Bàn Trống": 
                        btn.BackColor = Color.Gray;
                        break;
                    default:
                        btn.BackColor = Color.Pink;
                        break;
                }
                flpTable.Controls.Add(btn);
            }

            void ShowBill(int id)
            {
                lsvBill.Items.Clear();
                List<InvoiceShow> ListBillInfo = ShowInvoiceDAL.Instance.GetListShowInvoiceByTable(id);

                foreach (InvoiceShow item in ListBillInfo)
                {
                    ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                    lsvItem.SubItems.Add(item.SoLuong.ToString());
                    lsvItem.SubItems.Add(item.Price.ToString());
                    lsvItem.SubItems.Add(item.TotalPrice.ToString());

                    lsvBill.Items.Add(lsvItem);
                }
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
                    }
                }
            }


        }

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
