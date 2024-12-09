
﻿namespace QL_sald
{
    partial class BaoCao
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2Button();
            this.checkOutDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.checkInDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridViewInvoices = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flpTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl1
            // 
            this.tabControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(935, 492);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnThongKe);
            this.tabPage2.Controls.Add(this.checkOutDate);
            this.tabPage2.Controls.Add(this.checkInDate);
            this.tabPage2.Controls.Add(this.flpTable);
            this.tabPage2.ForeColor = System.Drawing.Color.Black;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(927, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hóa Đơn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Danh sách hóa đơn đã thanh toán";
            // 
            // btnThongKe
            // 
            this.btnThongKe.BorderRadius = 20;
            this.btnThongKe.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThongKe.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThongKe.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(339, 12);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(135, 29);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // checkOutDate
            // 
            this.checkOutDate.BorderRadius = 15;
            this.checkOutDate.Checked = true;
            this.checkOutDate.FillColor = System.Drawing.Color.Cyan;
            this.checkOutDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.checkOutDate.Location = new System.Drawing.Point(650, 12);
            this.checkOutDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkOutDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.checkOutDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.checkOutDate.Name = "checkOutDate";
            this.checkOutDate.Size = new System.Drawing.Size(165, 29);
            this.checkOutDate.TabIndex = 1;
            this.checkOutDate.Value = new System.DateTime(2024, 12, 9, 0, 30, 20, 800);
            // 
            // checkInDate
            // 
            this.checkInDate.BorderRadius = 15;
            this.checkInDate.Checked = true;
            this.checkInDate.FillColor = System.Drawing.Color.Cyan;
            this.checkInDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkInDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.checkInDate.Location = new System.Drawing.Point(143, 12);
            this.checkInDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkInDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.checkInDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.checkInDate.Name = "checkInDate";
            this.checkInDate.Size = new System.Drawing.Size(165, 29);
            this.checkInDate.TabIndex = 0;
            this.checkInDate.Value = new System.DateTime(2024, 12, 9, 0, 29, 59, 652);
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpTable.Controls.Add(this.dataGridViewInvoices);
            this.flpTable.Location = new System.Drawing.Point(2, 105);
            this.flpTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(825, 342);
            this.flpTable.TabIndex = 3;
            // 
            // dataGridViewInvoices
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.dataGridViewInvoices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInvoices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewInvoices.ColumnHeadersHeight = 4;
            this.dataGridViewInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewInvoices.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewInvoices.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewInvoices.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewInvoices.Name = "dataGridViewInvoices";
            this.dataGridViewInvoices.RowHeadersVisible = false;
            this.dataGridViewInvoices.RowHeadersWidth = 51;
            this.dataGridViewInvoices.Size = new System.Drawing.Size(839, 338);
            this.dataGridViewInvoices.TabIndex = 0;
            this.dataGridViewInvoices.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewInvoices.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dataGridViewInvoices.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dataGridViewInvoices.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dataGridViewInvoices.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dataGridViewInvoices.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewInvoices.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewInvoices.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dataGridViewInvoices.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewInvoices.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dataGridViewInvoices.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewInvoices.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridViewInvoices.ThemeStyle.HeaderStyle.Height = 4;
            this.dataGridViewInvoices.ThemeStyle.ReadOnly = false;
            this.dataGridViewInvoices.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewInvoices.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridViewInvoices.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dataGridViewInvoices.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dataGridViewInvoices.ThemeStyle.RowsStyle.Height = 22;
            this.dataGridViewInvoices.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dataGridViewInvoices.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày bắt đầu";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(519, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ngày kết thúc";
            // 
            // BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 492);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaoCao";
            this.Text = "BaoCao";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.flpTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;


        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private Guna.UI2.WinForms.Guna2Button btnThongKe;
        private Guna.UI2.WinForms.Guna2DateTimePicker checkOutDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker checkInDate;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private Guna.UI2.WinForms.Guna2DataGridView dataGridViewInvoices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }

}