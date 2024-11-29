namespace QL_sald.table
{
    partial class TableCPT
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.label_ban = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.label_tt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.guna2Panel1.Controls.Add(this.label_tt);
            this.guna2Panel1.Controls.Add(this.label_ban);
            this.guna2Panel1.Location = new System.Drawing.Point(14, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(232, 116);
            this.guna2Panel1.TabIndex = 0;
      
            // 
            // label_ban
            // 
            this.label_ban.BackColor = System.Drawing.Color.Transparent;
            this.label_ban.Location = new System.Drawing.Point(21, 31);
            this.label_ban.Name = "label_ban";
            this.label_ban.Size = new System.Drawing.Size(43, 15);
            this.label_ban.TabIndex = 0;
            this.label_ban.Text = "Tên bàn";
            // 
            // label_tt
            // 
            this.label_tt.BackColor = System.Drawing.Color.Transparent;
            this.label_tt.Location = new System.Drawing.Point(21, 77);
            this.label_tt.Name = "label_tt";
            this.label_tt.Size = new System.Drawing.Size(51, 15);
            this.label_tt.TabIndex = 1;
            this.label_tt.Text = "Trạng thái";
            // 
            // TableCPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "TableCPT";
            this.Size = new System.Drawing.Size(268, 137);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel label_tt;
        private Guna.UI2.WinForms.Guna2HtmlLabel label_ban;
    }
}
