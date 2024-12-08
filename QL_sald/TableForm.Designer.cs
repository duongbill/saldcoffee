namespace QL_sald
{
    partial class TableForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddTable = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelTable = new Guna.UI2.WinForms.Guna2Button();
            this.cbCount = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.btn_them = new Guna.UI2.WinForms.Guna2Button();
            this.cbCategories = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbFood = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_thanhtoan = new Guna.UI2.WinForms.Guna2Button();
            this.txtTotalPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCount)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(924, 507);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAddTable);
            this.tabPage1.Controls.Add(this.btnDelTable);
            this.tabPage1.Controls.Add(this.cbCount);
            this.tabPage1.Controls.Add(this.btn_them);
            this.tabPage1.Controls.Add(this.cbCategories);
            this.tabPage1.Controls.Add(this.cbFood);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btn_thanhtoan);
            this.tabPage1.Controls.Add(this.txtTotalPrice);
            this.tabPage1.Controls.Add(this.lsvBill);
            this.tabPage1.Controls.Add(this.flpTable);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(916, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dùng tại bàn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddTable
            // 
            this.btnAddTable.BorderRadius = 10;
            this.btnAddTable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddTable.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnAddTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddTable.ForeColor = System.Drawing.Color.White;
            this.btnAddTable.Location = new System.Drawing.Point(6, 428);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(111, 36);
            this.btnAddTable.TabIndex = 12;
            this.btnAddTable.Text = "Thêm bàn";
            // 
            // btnDelTable
            // 
            this.btnDelTable.BorderRadius = 10;
            this.btnDelTable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelTable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelTable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelTable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelTable.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDelTable.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelTable.ForeColor = System.Drawing.Color.White;
            this.btnDelTable.Location = new System.Drawing.Point(146, 428);
            this.btnDelTable.Name = "btnDelTable";
            this.btnDelTable.Size = new System.Drawing.Size(111, 36);
            this.btnDelTable.TabIndex = 11;
            this.btnDelTable.Text = "Xóa bàn";
            this.btnDelTable.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbCount
            // 
            this.cbCount.BackColor = System.Drawing.Color.Transparent;
            this.cbCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cbCount.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbCount.Location = new System.Drawing.Point(622, 12);
            this.cbCount.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.cbCount.Name = "cbCount";
            this.cbCount.Size = new System.Drawing.Size(88, 36);
            this.cbCount.TabIndex = 10;
            // 
            // btn_them
            // 
            this.btn_them.BorderRadius = 10;
            this.btn_them.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_them.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_them.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_them.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_them.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_them.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_them.ForeColor = System.Drawing.Color.White;
            this.btn_them.Location = new System.Drawing.Point(721, 12);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(89, 36);
            this.btn_them.TabIndex = 9;
            this.btn_them.Text = "Thêm món";
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // cbCategories
            // 
            this.cbCategories.BackColor = System.Drawing.Color.Transparent;
            this.cbCategories.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategories.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategories.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbCategories.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbCategories.ItemHeight = 30;
            this.cbCategories.Location = new System.Drawing.Point(415, 12);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(201, 36);
            this.cbCategories.TabIndex = 8;
            this.cbCategories.SelectedIndexChanged += new System.EventHandler(this.cbCategories_SelectedIndexChanged);
            // 
            // cbFood
            // 
            this.cbFood.BackColor = System.Drawing.Color.Transparent;
            this.cbFood.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFood.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFood.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFood.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFood.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFood.ItemHeight = 30;
            this.cbFood.Location = new System.Drawing.Point(415, 54);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(395, 36);
            this.cbFood.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(416, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tổng tiền hóa đơn";
            // 
            // btn_thanhtoan
            // 
            this.btn_thanhtoan.BorderRadius = 15;
            this.btn_thanhtoan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_thanhtoan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_thanhtoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_thanhtoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_thanhtoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_thanhtoan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_thanhtoan.ForeColor = System.Drawing.Color.White;
            this.btn_thanhtoan.Location = new System.Drawing.Point(699, 428);
            this.btn_thanhtoan.Name = "btn_thanhtoan";
            this.btn_thanhtoan.Size = new System.Drawing.Size(111, 44);
            this.btn_thanhtoan.TabIndex = 5;
            this.btn_thanhtoan.Text = "Thanh toán";
            this.btn_thanhtoan.Click += new System.EventHandler(this.btn_thanhtoan_Click);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalPrice.DefaultText = "0";
            this.txtTotalPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotalPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotalPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalPrice.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.txtTotalPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalPrice.Location = new System.Drawing.Point(558, 428);
            this.txtTotalPrice.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.PasswordChar = '\0';
            this.txtTotalPrice.PlaceholderText = "";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.SelectedText = "";
            this.txtTotalPrice.Size = new System.Drawing.Size(133, 36);
            this.txtTotalPrice.TabIndex = 4;
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(415, 96);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(395, 321);
            this.lsvBill.TabIndex = 3;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 172;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 62;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giá";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tổng tiền";
            this.columnHeader4.Width = 88;
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpTable.Location = new System.Drawing.Point(6, 6);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(399, 411);
            this.flpTable.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(916, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Đơn Onl";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 531);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_thanhtoan;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalPrice;
        private Guna.UI2.WinForms.Guna2Button btn_them;
        private Guna.UI2.WinForms.Guna2ComboBox cbCategories;
        private Guna.UI2.WinForms.Guna2ComboBox cbFood;
        private Guna.UI2.WinForms.Guna2NumericUpDown cbCount;

        private Guna.UI2.WinForms.Guna2Button btnAddTable;
        private Guna.UI2.WinForms.Guna2Button btnDelTable;
    }
}

//day code chuan len