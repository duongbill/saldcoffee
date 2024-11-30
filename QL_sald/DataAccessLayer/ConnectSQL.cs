﻿using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAcessLayer
{
    public class ConnectSQL
    {
        private SqlConnection conn;

        public ConnectSQL()
        {
            conn = new SqlConnection("Server=localhost,1433;Database=quanly_sald;User Id=sa;Password=123456;TrustServerCertificate=True;");
        }

        // Hàm kiểm tra kết nối và in ra thông báo
        private bool CheckConnection()
        {
            try
            {
                conn.Open();
                Console.WriteLine("Kết nối thành công!");
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Kết nối thất bại: " + ex.Message);
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        // cai nay de doc du lieu cho vao datatable nhu cai datagidview j y
        public DataTable GetData(string strSQL) // Dùng để thực hiện truy vấn Select
        {
            DataTable dt = new DataTable();
            if (CheckConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                conn.Open();
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }
        //  doc proc dang bang
        public DataTable GetData(string procName, SqlParameter[] para)
        {
            DataTable dt = new DataTable();
            if (CheckConnection())
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = procName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn
                };
                if (para != null)
                    cmd.Parameters.AddRange(para);
                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = cmd
                };
                conn.Open();
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }
        // dung de insert update delete 
        public int ExecuteSQL(string strSQL)
        {
            int row = 0;
            if (CheckConnection())
            {
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                conn.Open();
                row = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return row;
        }
        // cai nay dung de doc proc 
        public int ExecuteSQL(string procName, SqlParameter[] para)
        {
            int row = 0;
            if (CheckConnection())
            {
                SqlCommand cmd = new SqlCommand
                {
                    CommandText = procName,
                    CommandType = CommandType.StoredProcedure,
                    Connection = conn
                };
                if (para != null)
                    cmd.Parameters.AddRange(para);
                conn.Open();
                row = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return row;
        }

        public object ExecuteScaler(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                connection.Open();
                return command.ExecuteScalar();
            }
        }

    }

}
