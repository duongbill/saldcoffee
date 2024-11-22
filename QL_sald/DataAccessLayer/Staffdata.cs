using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QL_sald.DataAccessLayer
{
    class Staffdata
    {
        private SqlConnection conn = new SqlConnection(@"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;");

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;");
        }

        public DataTable sfData()
        {
            DataTable dataTable = new DataTable();

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                string selectData = "SELECT s.StaffId, s.FullName, s.Phone, s.DateOfBirth, s.Email, s.Gender, a.RoleName " +
                                    "FROM Staff s " +
                                    "INNER JOIN AccRole a ON s.RoleId = a.RoleId;";

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
            finally
            {
                conn.Close();
            }

            return dataTable;
        }

    }
}
