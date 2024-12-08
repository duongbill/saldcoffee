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
    using System.Windows.Forms;

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
                DataTable data = connectSQL.GetData($"update Invoice set TrangThai = 1 where InvoiceId = {id} ");

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
            //tinh tong so ban
            public int GetTotalInvoices()
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM Invoice";
                    object result = connectSQL.ExecuteScaler(query);
                    return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while calculating total invoices: {ex.Message}");
                    return 0; // Trả về 0 nếu xảy ra lỗi
                }
            }

            // tinh totalPrice
            public decimal GetTotalRevenue()
            {
                try
                {
                    string query = "SELECT SUM(TotalPrice) FROM Invoice WHERE TrangThai = 1";
                    object result = connectSQL.ExecuteScaler(query); // Sử dụng connectSQL thay vì DataProvider
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while calculating total revenue: {ex.Message}");
                    return 0; // Trả về 0 nếu xảy ra lỗi
                }
            }



        }
    }
