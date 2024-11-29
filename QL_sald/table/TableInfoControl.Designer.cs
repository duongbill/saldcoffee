namespace QL_sald.table
{
    partial class TableInfoControl
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
        private void InitializeComponent()
        {
            this.labelTableName = new System.Windows.Forms.Label();
            this.labelTrangThai = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTableName
            // 
            this.labelTableName.AutoSize = true;
            this.labelTableName.Location = new System.Drawing.Point(138, 35);
            this.labelTableName.Name = "labelTableName";
            this.labelTableName.Size = new System.Drawing.Size(25, 13);
            this.labelTableName.TabIndex = 0;
            this.labelTableName.Text = "abc";
            this.labelTableName.Click += new System.EventHandler(this.labelTableName_Click);
            // 
            // labelTrangThai
            // 
            this.labelTrangThai.AutoSize = true;
            this.labelTrangThai.Location = new System.Drawing.Point(20, 66);
            this.labelTrangThai.Name = "labelTrangThai";
            this.labelTrangThai.Size = new System.Drawing.Size(22, 13);
            this.labelTrangThai.TabIndex = 1;
            this.labelTrangThai.Text = "efd";
            this.labelTrangThai.Click += new System.EventHandler(this.labelTrangThai_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // TableInfoControl
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTrangThai);
            this.Controls.Add(this.labelTableName);
            this.Name = "TableInfoControl";
            this.Size = new System.Drawing.Size(250, 100);
            this.Load += new System.EventHandler(this.TableInfoControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion

        private System.Windows.Forms.Label labelTableName;
        private System.Windows.Forms.Label labelTrangThai;
        private System.Windows.Forms.Label label1;
    }
}
