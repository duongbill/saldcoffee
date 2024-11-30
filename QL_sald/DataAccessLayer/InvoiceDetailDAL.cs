using DataAcessLayer;
using QL_sald.logicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using Microsoft.Data.SqlClient;
using System.Web.UI.Design.WebControls;
using System.Windows.Forms;
namespace QL_sald.DataAccessLayer
{
    public class InvoiceDetailDAL
    {
        private static InvoiceDetailDAL instance;
        ConnectSQL connectSQL = new ConnectSQL();
        FoodLL foodLL = new FoodLL();
        public static InvoiceDetailDAL Instance
        {
            get { if (instance == null) instance = new InvoiceDetailDAL(); return InvoiceDetailDAL.instance; }
            private set { InvoiceDetailDAL.instance = value; }
        }

        private InvoiceDetailDAL() { }

        public List<InvoiceDetail> GetListBillInfo(int id)
        {
            List<InvoiceDetail> listBill = new List<InvoiceDetail>();

            ConnectSQL connectSQL = new ConnectSQL();
            DataTable data = connectSQL.GetData($"select * from InvoiceDetail where InvoiceId = {id} ");

            foreach (DataRow row in data.Rows)
            {
                InvoiceDetail invoiceDetail = new InvoiceDetail(row);
                listBill.Add(invoiceDetail);

            }


            return listBill;
        }

        public void InsertBillDetail(int invoiceId, int foodId, int soluong)
        {
            try
            {
                // Giả sử bạn cần lấy giá trị Price từ bảng Food
                decimal price = foodLL.GetFoodPriceById(foodId); // Sử dụng phương thức để lấy giá trị Price từ bảng Food

                // Print out values for debugging
                Console.WriteLine($"InvoiceId: {invoiceId}, FoodId: {foodId}, SoLuong: {soluong}, Price: {price}");

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@InvoiceId", invoiceId),
            new SqlParameter("@FoodId", foodId),
            new SqlParameter("@SoLuong", soluong),
            new SqlParameter("@Price", price) // Truyền giá trị Price
                };

                // In ra giá trị của từng tham số
                foreach (var param in parameters)
                {
                    Console.WriteLine($"Parameter Name: {param.ParameterName}, Value: {param.Value}");
                }

                // Execute stored procedure
                DataTable resultTable = connectSQL.ExecuteData1("Proc_InsertBillDetail", parameters);

                // Check the result
                if (resultTable.Rows.Count > 0)
                {
                    Console.WriteLine("Thêm thành công.");
                }
                else
                {
                    Console.WriteLine("Thất bại.");
                }

                // Display data in result table
                foreach (DataRow row in resultTable.Rows)
                {
                    Console.WriteLine($"InvoiceId: {row["InvoiceId"]}, FoodId: {row["FoodId"]}, SoLuong: {row["SoLuong"]}, Price: {row["Price"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


    }
}
