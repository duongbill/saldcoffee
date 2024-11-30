using DataAcessLayer;
using QL_sald.ValueObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace QL_sald.DataAccessLayer
{
    public class ShowInvoiceDAL
    {
        private static ShowInvoiceDAL instance;

        public static ShowInvoiceDAL Instance
        {
            get { if (instance == null) instance = new ShowInvoiceDAL(); return ShowInvoiceDAL.instance; }
            private set { ShowInvoiceDAL.instance = value; }
        }
        private ShowInvoiceDAL() { }

        public List<InvoiceShow> GetListShowInvoiceByTable(int id)
        {
            List<InvoiceShow> listShow = new List<InvoiceShow>();

            ConnectSQL connectSQL = new ConnectSQL();
            DataTable data = connectSQL.GetData($"SELECT f.FoodName, bi.SoLuong, f.Price, f.Price * bi.SoLuong AS TotalPrice" +
                $"\r\nFROM InvoiceDetail AS bi\r\nINNER JOIN Invoice AS b ON bi.InvoiceId = b.InvoiceId" +
                $"\r\nINNER JOIN Food AS f ON bi.FoodId = f.FoodId\r\nWHERE b.TableId = {id}");

            foreach (DataRow row in data.Rows)
            {
                InvoiceShow show = new InvoiceShow(row);
                listShow.Add(show);
            }

            return listShow;
        }
    }
}
