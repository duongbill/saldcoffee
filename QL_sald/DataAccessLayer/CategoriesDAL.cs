using System;
using System.Collections.Generic;
using System.Data;
using DataAcessLayer;
using Microsoft.Data.SqlClient;
using QL_sald.logicLayer;
using ValueObject;

namespace QL_sald.DataAccessLayer
{
    internal class CategoriesDAL
    {
        private ConnectSQL connectSQL = new ConnectSQL();
        private static CategoriesDAL instance;
        public static CategoriesDAL Instance

        {
            get { if (instance == null) instance = new CategoriesDAL(); return CategoriesDAL.instance; }
            private set { CategoriesDAL.instance = value; }
        }
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
    
    public List<Category> GetCategories()
        {
            List<Category> listCate = new List<Category>();

            ConnectSQL connectSQL = new ConnectSQL();
            DataTable data = connectSQL.GetData($" select * from Category  ");
            foreach (DataRow row in data.Rows)
            {
                Category cate = new Category(row);
                listCate.Add(cate);

            }
            return listCate;
        }
    }
}
