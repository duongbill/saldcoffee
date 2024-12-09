using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QL_sald.ValueObject;

namespace QL_sald.DataAccessLayer
{
    public class TableDAL
    {
        // Chuỗi kết nối đến cơ sở dữ liệu
        private readonly string connectionString = @"Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;";

        // Singleton cho TableDAL
        private static TableDAL instance;

        public static TableDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new TableDAL();
                return instance;
            }
            private set { instance = value; }
        }

        public TableDAL() { }

        public List<TableFood> LoadTableList()
        {
            List<TableFood> tableList = new List<TableFood>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM TableFood"; // Truy vấn danh sách bàn

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        foreach (DataRow row in data.Rows)
                        {
                            TableFood table = new TableFood(row);
                            tableList.Add(table);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tải danh sách bàn: {ex.Message}");
            }

            return tableList;
        }

        public bool InsertTable()
        {
            string query = "INSERT INTO TableFood (TableName, TrangThai) VALUES (@tableName, @status)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Tạo tên bàn tự động dựa trên số lượng bàn hiện có
                        int tableCount = GetTableCount();
                        string tableName = "Table " + (tableCount + 1);

                        // Gán tham số
                        command.Parameters.AddWithValue("@tableName", tableName);
                        command.Parameters.AddWithValue("@status", "Bàn Trống");

                        int result = command.ExecuteNonQuery();
                        return result > 0; // Trả về true nếu thêm thành công
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi thêm bàn: {ex.Message}");
                return false;
            }
        }

        private int GetTableCount()
        {
            string query = "SELECT COUNT(*) FROM TableFood";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        return (int)command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đếm bàn: {ex.Message}");
                return 0;
            }
        }
        public bool DeleteTable(int tableId)
        {
            string query = "DELETE FROM TableFood WHERE TableId = @tableId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Gán tham số
                        command.Parameters.AddWithValue("@tableId", tableId);

                        int result = command.ExecuteNonQuery();
                        return result > 0; // Trả về true nếu xóa thành công
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa bàn: {ex.Message}");
                return false;
            }
        }
    }
}
