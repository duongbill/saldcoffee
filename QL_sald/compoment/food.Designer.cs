namespace QL_sald
{
    partial class food
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

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFoodItems;

       

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(food));
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtPrice = new System.Windows.Forms.Label();
            this.txtFoodName = new System.Windows.Forms.Label();
       
            this.panel7.SuspendLayout();
           
            this.SuspendLayout();



            /// add
            this.flowLayoutPanelFoodItems = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            // 
            // flowLayoutPanelFoodItems
            // 
            this.flowLayoutPanelFoodItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFoodItems.AutoScroll = true;
            this.Controls.Add(this.flowLayoutPanelFoodItems);

            // 
            // food
            // 
            this.Name = "food";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            // 
            // panel7
            // 

            this.panel7.Controls.Add(this.txtPrice);
            this.panel7.Controls.Add(this.txtFoodName);
            this.panel7.Location = new System.Drawing.Point(2, 2);
            this.panel7.Margin = new System.Windows.Forms.Padding(2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(148, 182);
            this.panel7.TabIndex = 10;
            // 
            // txtPrice
            // 
            this.txtPrice.AutoSize = true;
            this.txtPrice.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtPrice.Location = new System.Drawing.Point(2, 151);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(45, 17);
            this.txtPrice.TabIndex = 3;
            this.txtPrice.Text = "45.000đ";
            this.txtPrice.UseCompatibleTextRendering = true;
            // 
            // txtFoodName
            // 
            this.txtFoodName.AutoSize = true;
            this.txtFoodName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtFoodName.Location = new System.Drawing.Point(2, 131);
            this.txtFoodName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.Size = new System.Drawing.Size(134, 12);
            this.txtFoodName.TabIndex = 2;
            this.txtFoodName.Text = "Trà xanh espresso marble";
         
            // 
            // food
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel7);
            this.Name = "food";
            this.Size = new System.Drawing.Size(140, 173);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
      
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label txtPrice;
        private System.Windows.Forms.Label txtFoodName;
     
    }
}
