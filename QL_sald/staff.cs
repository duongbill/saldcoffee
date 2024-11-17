using QL_sald.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_sald.DataAccessLayer;

namespace QL_sald
{
    public partial class staff : Form
    {
        public staff()
        {
            InitializeComponent();

            displayStaffData();
        }

        public void displayStaffData()
        {
            Staffdata data = new Staffdata();
            DataTable dataTable = data.sfData();
            viewStaff.DataSource = dataTable;  // Gán DataTable cho DataSource của DataGridView
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

        }
    }
}
