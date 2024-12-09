using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using QL_sald.ValueObject;
using ValueObject;

namespace QL_sald.DataAccessLayer
{
    public class InvoiceDAL
    {
        private static InvoiceDAL instance;
        private readonly string connectionString = @"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;TrustServerCertificate=True;";

        // Singleton instance
        public static InvoiceDAL Instance
        {
            get { if (instance == null) instance = new InvoiceDAL(); return instance; }
            private set { instance = value; }
        }

        private InvoiceDAL() { }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Lấy danh sách hóa đơn
        public DataTable sfData()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string selectData = "SELECT Invoice.TableId, Invoice.DateCheckIn, Invoice.DateCheckOut, Invoice.TotalPrice, Invoice.TrangThai FROM Invoice";
                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);  // Lưu trữ dữ liệu vào DataTable
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
            return dataTable;
        }

        // Lấy hóa đơn chưa thanh toán theo TableId
        public int GetUncheckInvoiceByTableID(int id)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Invoice WHERE TableId = @TableId AND TrangThai = 0";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableId", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToInt32(reader["InvoiceId"]);
                        }
                    }
                }
            }
            return -1; // Không có hóa đơn nào chưa thanh toán
        }

        // Đánh dấu hóa đơn là đã thanh toán

        public void CheckOut(int id)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "UPDATE Invoice \r\nSET \r\n    DateCheckOut = GETDATE(), \r\n    " +
                    "TrangThai = 1, \r\n    Total = (SELECT SUM(bdt.Price * bdt.SoLuong)\r\n            " +
                    " FROM InvoiceDetail AS bdt\r\n             WHERE bdt.InvoiceId = Invoice.InvoiceId)\r\nWHERE " +
                    "InvoiceId = @InvoiceId;\r\n";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InvoiceId", id);
                    command.ExecuteNonQuery();
                }
            }
        }


        public DataTable GetBillByDate(DateTime checkin, DateTime checkout)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string selectData = "EXEC usp_GetBillByDate @datecheckin, @datecheckout;";
                    using (SqlCommand cmd = new SqlCommand(selectData, conn))
                    {
                        cmd.Parameters.AddWithValue("@datecheckin", checkin);
                        cmd.Parameters.AddWithValue("@datecheckout", checkout);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);  // Lưu trữ dữ liệu vào DataTable
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
            return dataTable;
        }



        // Thêm hóa đơn mới
        public void InsertBill(int id)
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TableId", id)
                    };

                    string procedure = "Proc_InsertBill";
                    using (SqlCommand command = new SqlCommand(procedure, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(parameters);
                        int affectedRows = command.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            Console.WriteLine("Thêm thành công.");
                        }
                        else
                        {
                            Console.WriteLine("Thất bại.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Lấy ID hóa đơn tối đa
        public int GetMaxBill()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT MAX(InvoiceId) FROM Invoice";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToInt32(result) : 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }

        // Tính tổng số hóa đơn
        public int GetTotalInvoices()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Invoice";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while calculating total invoices: {ex.Message}");
                return 0;
            }
        }

        // Tính tổng doanh thu
        public decimal GetTotalRevenue()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "SELECT SUM(TotalPrice) FROM Invoice WHERE TrangThai = 1";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while calculating total revenue: {ex.Message}");
                return 0;
            }
        }

        // Lấy danh sách hóa đơn theo ngày
        public DataTable GetListInvoiceByDate(DateTime checkIn, DateTime checkOut)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "exec USP_GetListInvoiceByDate @checkIn, @checkOut";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@checkIn", checkIn);
                        command.Parameters.AddWithValue("@checkOut", checkOut);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching invoices: {ex.Message}");
            }

            return dataTable;
        }
    }
}
