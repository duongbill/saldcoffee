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
    public partial class daxaydrink : UserControl
    {
        public daxaydrink()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.menuthucuongdaxay1 = new QL_sald.menuthucuongdaxay();
            this.SuspendLayout();
            // 
            // menuthucuongdaxay1
            // 
            this.menuthucuongdaxay1.Location = new System.Drawing.Point(250, 150);
            this.menuthucuongdaxay1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.menuthucuongdaxay1.Name = "menuthucuongdaxay1";
            this.menuthucuongdaxay1.Size = new System.Drawing.Size(1121, 745);
            this.menuthucuongdaxay1.TabIndex = 0;
            // 
            // test
            // 
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.menuthucuongdaxay1);
            this.Name = "test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }
    }
}
