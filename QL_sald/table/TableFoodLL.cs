
using System.Data;


namespace QL_sald.table
{

    public class TableFoodLL
    {
        private TableFoodDAL tableFoodDAL;

        public TableFoodLL()
        {
            tableFoodDAL = new TableFoodDAL();
        }

        public DataTable GetTableDetails(int tableId)
        {
            return tableFoodDAL.GetTableById(tableId);
        }
    }
}
