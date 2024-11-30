using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using DataAcessLayer;
using QL_sald.DataAccessLayer;
using Microsoft.Data.SqlClient;
using System.Data;
using QL_sald.ValueObject;
using ValueObject;
using System.Windows.Markup;

namespace QL_sald.DataAccessLayer
{
    public class InvoiceDAL
    {
        ConnectSQL connectSQL = new ConnectSQL();
        private static InvoiceDAL instance;

        public static InvoiceDAL Instance
        {
            get { if (instance == null) instance = new InvoiceDAL(); return InvoiceDAL.instance; }
            private set { InvoiceDAL.instance = value; }
        }

        private InvoiceDAL() { }



        public int GetUncheckInvoiceByTableID(int id)
        {
            
            DataTable data = connectSQL.GetData($"SELECT * FROM invoice WHERE TableId = {id} AND TrangThai = 0");

            if (data.Rows.Count > 0)
            {
                Invoice bill = new Invoice(data.Rows[0]);
                return bill.InvoiceId;
            }
            return -1; // Không có hóa đơn nào chưa thanh toán
        }
        public void CheckOut(int id)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@InvoiceId", id)
                };

                DataTable data = connectSQL.ExecuteData1("update Invoice set TrangThai = 1 where InvoiceId = @InvoiceId", parameters);
                Console.WriteLine("Checkout thành công.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }






        public void InsertBill(int id)
        {
            try
            {
                // Khởi tạo tham số SqlParameter
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@TableId", id)
                };

                // Thực hiện stored procedure và lấy số hàng bị ảnh hưởng
                int affectedRows = connectSQL.ExecuteSQL("Proc_InsertBill", parameters);

                // Kiểm tra kết quả trả về
                if (affectedRows > 0)
                {
                    Console.WriteLine("Thêm thành công.");
                }
                else
                {
                    Console.WriteLine("Thất bại.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // ham lay id bill max de truyen vao
        public int GetMaxBill()
        {
            try
            {
                // Gọi phương thức ExecuteScalar để lấy giá trị tối đa của InvoiceId
                object result = connectSQL.ExecuteScaler("SELECT MAX(InvoiceId) FROM Invoice");

                // Kiểm tra và chuyển đổi kết quả trả về
                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    return 1; // Trả về giá trị mặc định nếu không có kết quả
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Error: {ex.Message}");
                return 1; // Trả về giá trị mặc định nếu có lỗi
            }
        }


    }
}
