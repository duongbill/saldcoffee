namespace QL_sald.compoment
{
    partial class FoodCPT
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
            this.pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtPrice = new System.Windows.Forms.Label();
            this.txtFoodName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // pic
            // 
            this.pic.FillColor = System.Drawing.Color.RosyBrown;
            this.pic.ImageRotate = 0F;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(150, 144);
            this.pic.TabIndex = 0;
            this.pic.TabStop = false;
            // 
            // txtPrice
            // 
            this.txtPrice.AutoSize = true;
            this.txtPrice.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtPrice.Location = new System.Drawing.Point(2, 169);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(45, 17);
            this.txtPrice.TabIndex = 6;
            this.txtPrice.Text = "35.000đ";
            this.txtPrice.UseCompatibleTextRendering = true;
            // 
            // txtFoodName
            // 
            this.txtFoodName.AutoSize = true;
            this.txtFoodName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtFoodName.Location = new System.Drawing.Point(-1, 147);
            this.txtFoodName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.Size = new System.Drawing.Size(74, 12);
            this.txtFoodName.TabIndex = 5;
            this.txtFoodName.Text = "Tên sản phẩm";
            this.txtFoodName.Click += new System.EventHandler(this.txtFoodName_Click);
            // 
            // FoodCPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtFoodName);
            this.Controls.Add(this.pic);
            this.Name = "FoodCPT";
            this.Size = new System.Drawing.Size(150, 186);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pic;
        private System.Windows.Forms.Label txtPrice;
        private System.Windows.Forms.Label txtFoodName;
    }
}
