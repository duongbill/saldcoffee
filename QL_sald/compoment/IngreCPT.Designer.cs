namespace QL_sald.compoment
{
    partial class IngreCPT
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
            this.txtQuantity = new System.Windows.Forms.Label();
            this.txtIngredientName = new System.Windows.Forms.Label();
            this.pic = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lbl_sl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQuantity
            // 
            this.txtQuantity.AutoSize = true;
            this.txtQuantity.ForeColor = System.Drawing.Color.Red;
            this.txtQuantity.Location = new System.Drawing.Point(28, 166);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(29, 17);
            this.txtQuantity.TabIndex = 9;
            this.txtQuantity.Text = "1000";
            this.txtQuantity.UseCompatibleTextRendering = true;
            // 
            // txtIngredientName
            // 
            this.txtIngredientName.AutoSize = true;
            this.txtIngredientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtIngredientName.Location = new System.Drawing.Point(2, 147);
            this.txtIngredientName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(87, 13);
            this.txtIngredientName.TabIndex = 8;
            this.txtIngredientName.Text = "Tên sản phẩm";
            // 
            // pic
            // 
            this.pic.FillColor = System.Drawing.Color.DimGray;
            this.pic.ImageRotate = 0F;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(138, 144);
            this.pic.TabIndex = 7;
            this.pic.TabStop = false;
            // 
            // lbl_sl
            // 
            this.lbl_sl.AutoSize = true;
            this.lbl_sl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_sl.Location = new System.Drawing.Point(3, 166);
            this.lbl_sl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_sl.Name = "lbl_sl";
            this.lbl_sl.Size = new System.Drawing.Size(25, 12);
            this.lbl_sl.TabIndex = 10;
            this.lbl_sl.Text = "SL: ";
            // 
            // IngreCPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_sl);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtIngredientName);
            this.Controls.Add(this.pic);
            this.Name = "IngreCPT";
            this.Size = new System.Drawing.Size(156, 193);
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtQuantity;
        private System.Windows.Forms.Label txtIngredientName;
        private Guna.UI2.WinForms.Guna2PictureBox pic;
        private System.Windows.Forms.Label lbl_sl;
    }
}
