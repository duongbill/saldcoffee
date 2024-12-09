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
            this.txtQuantity.Location = new System.Drawing.Point(41, 202);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(35, 20);
            this.txtQuantity.TabIndex = 9;
            this.txtQuantity.Text = "1000";
            this.txtQuantity.UseCompatibleTextRendering = true;
            this.txtQuantity.Click += new System.EventHandler(this.txtQuantity_Click_1);
            // 
            // txtIngredientName
            // 
            this.txtIngredientName.AutoSize = true;
            this.txtIngredientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtIngredientName.Location = new System.Drawing.Point(3, 181);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(111, 17);
            this.txtIngredientName.TabIndex = 8;
            this.txtIngredientName.Text = "Tên sản phẩm";
            // 
            // pic
            // 
            this.pic.FillColor = System.Drawing.Color.DimGray;
            this.pic.ImageRotate = 0F;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(184, 177);
            this.pic.TabIndex = 7;
            this.pic.TabStop = false;
            // 
            // lbl_sl
            // 
            this.lbl_sl.AutoSize = true;
            this.lbl_sl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbl_sl.Location = new System.Drawing.Point(3, 204);
            this.lbl_sl.Name = "lbl_sl";
            this.lbl_sl.Size = new System.Drawing.Size(32, 15);
            this.lbl_sl.TabIndex = 10;
            this.lbl_sl.Text = "SL: ";
            this.lbl_sl.Click += new System.EventHandler(this.lbl_sl_Click);
            // 
            // IngreCPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_sl);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtIngredientName);
            this.Controls.Add(this.pic);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "IngreCPT";
            this.Size = new System.Drawing.Size(208, 238);
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
