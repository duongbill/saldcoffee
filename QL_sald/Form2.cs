using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueObject;

namespace QL_sald
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LoadIngredientList();
        }
        void LoadIngredientList()
        {
            string connectionString = @"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from InvoiceDetail";
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            DataTable data = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            connection.Close();
            viewls.DataSource = data;
        }
        private void viewIngredient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
