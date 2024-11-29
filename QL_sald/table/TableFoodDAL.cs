using System;
using System.Data;
using System.Data.SqlClient;

namespace QL_sald.table
{


    public class TableFoodDAL
    {
        private string connectionString = "Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;TrustServerCertificate=True;";

        public DataTable GetTableById(int tableId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("GetTableById", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@TableId", tableId);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
