using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QL_sald.DataAccessLayer
{
    public class FoodData
    {
        private SqlConnection conn;

        public FoodData()
        {
            conn = new SqlConnection(@"Server=localhost,1433;Database=cafe_sald;User Id=sa;Password=123456;");
        }

        // Phương thức lấy dữ liệu món ăn
        public DataTable GetFoodData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("FoodName", typeof(string));
            dataTable.Columns.Add("Price", typeof(decimal));
            dataTable.Columns.Add("ImageURL", typeof(string));

            string query = "SELECT FoodName, Price, ImageURL FROM Food";

            try
            {
                using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DataRow row = dataTable.NewRow();
                                row["FoodName"] = reader["FoodName"];
                                row["Price"] = reader["Price"];
                                row["ImageURL"] = reader["ImageURL"];
                                dataTable.Rows.Add(row);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while accessing the database: " + ex.Message);
            }

            return dataTable;
        }
    }
}
