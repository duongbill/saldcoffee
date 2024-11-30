using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using QL_sald.ValueObject;
using QL_sald.DataAccessLayer;
using DataAcessLayer;
namespace QL_sald.DataAccessLayer
{
    public class TableDAL
    {
        private static TableDAL instance;

        public static TableDAL Instance
        {
            get { if (instance == null) instance = new TableDAL(); return TableDAL.instance; }
            private set { TableDAL.instance = value; }
        }

        public static int TableWidth = 120;
        public static int TableHeight = 120;

        private TableDAL() { }

        public List<TableFood> LoadTableList()
        {
            List<TableFood> tableList = new List<TableFood>();
            ConnectSQL connectSQL = new ConnectSQL();
            DataTable data = connectSQL.GetData("GetTableList");

            foreach (DataRow row in data.Rows)
            {
                TableFood table = new TableFood(row);
                tableList.Add(table);
            }
            return tableList;
        }
    }
}

