﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.Design.WebControls;
using DataAcessLayer;
using QL_sald.DataAccessLayer;
using Microsoft.Data.SqlClient;
using System.Data;
using QL_sald.ValueObject;

namespace QL_sald.DataAccessLayer
{
    public class InvoiceDAL
    {
        private static InvoiceDAL instance;

        public static InvoiceDAL Instance
        {
            get { if (instance == null) instance = new InvoiceDAL(); return InvoiceDAL.instance; }
            private set { InvoiceDAL.instance = value; }
        }

        private InvoiceDAL() { }



        public int GetUncheckInvoiceByTableID(int id)
        { 
            ConnectSQL connectSQL = new ConnectSQL();
            DataTable data = connectSQL.GetData("select * from invoice where TableId = "+ id +" and TrangThai = 0");

           if(data.Rows.Count > 0)
            {
                Invoice bill = new Invoice(data.Rows[0]);
                return bill.id;

            }return -1; // khong co thang nao het


        }
    }
}