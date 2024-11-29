using System;
using System.Collections.Generic;
using System.Data;
using DataAcessLayer;
using Microsoft.Data.SqlClient;
using ValueObject;

namespace QL_sald.DataAccessLayer
{
    internal class CategoriesDAL
    {
        private ConnectSQL connectSQL = new ConnectSQL();

        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            string query = "SELECT CategoryId, CategoryName FROM Category"; // Cập nhật tên bảng

            DataTable dt = connectSQL.GetData(query);

            foreach (DataRow row in dt.Rows)
            {
                Category category = new Category
                {
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    CategoryName = row["CategoryName"].ToString()
                };
                categories.Add(category);
            }

            return categories;
        }
    }
}
