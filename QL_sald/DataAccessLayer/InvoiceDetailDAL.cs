using DataAcessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace QL_sald.DataAccessLayer
{
    public class InvoiceDetailDAL
    {
        private static InvoiceDetailDAL instance;

        public static InvoiceDetailDAL Instance
        {
            get { if (instance == null) instance = new InvoiceDetailDAL(); return InvoiceDetailDAL.instance; }
            private set { InvoiceDetailDAL.instance = value; }
        }

        private InvoiceDetailDAL() { }

        public List<InvoiceDetail> GetListBillInfo(int id)
        {
            List<InvoiceDetail> listBill = new List<InvoiceDetail>();

            ConnectSQL connectSQL = new ConnectSQL();
            DataTable data = connectSQL.GetData($"select * from InvoiceDetail where InvoiceId = {id} ");

            foreach (DataRow row in data.Rows) {
                InvoiceDetail invoiceDetail = new InvoiceDetail(row);
                listBill.Add(invoiceDetail);

            }


            return listBill;
        }
    }
}
