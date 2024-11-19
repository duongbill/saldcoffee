using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_sald
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.sửa_tt_nhanvien1 = new QL_sald.sửa_tt_nhanvien();
            this.SuspendLayout();
            // 
            // sửa_tt_nhanvien1
            // 
            this.sửa_tt_nhanvien1.Location = new System.Drawing.Point(0, 0);
            this.sửa_tt_nhanvien1.Name = "sửa_tt_nhanvien1";
            this.sửa_tt_nhanvien1.Size = new System.Drawing.Size(1200, 700);
            this.sửa_tt_nhanvien1.TabIndex = 0;
            // 
            // test
            // 
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.sửa_tt_nhanvien1);
            this.Name = "test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }
    }
}
