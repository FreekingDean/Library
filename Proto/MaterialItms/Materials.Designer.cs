namespace Proto.MaterialItms
{
    partial class Materials
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
            this.btnPurchase = new System.Windows.Forms.Button();
            this.btnVendor = new System.Windows.Forms.Button();
            this.btnRecieve = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(11, 207);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(259, 59);
            this.btnPurchase.TabIndex = 5;
            this.btnPurchase.Text = "Purchase";
            this.btnPurchase.UseVisualStyleBackColor = true;
            // 
            // btnVendor
            // 
            this.btnVendor.Location = new System.Drawing.Point(12, 142);
            this.btnVendor.Name = "btnVendor";
            this.btnVendor.Size = new System.Drawing.Size(259, 59);
            this.btnVendor.TabIndex = 3;
            this.btnVendor.Text = "Vendor Maint";
            this.btnVendor.UseVisualStyleBackColor = true;
            // 
            // btnRecieve
            // 
            this.btnRecieve.Location = new System.Drawing.Point(12, 77);
            this.btnRecieve.Name = "btnRecieve";
            this.btnRecieve.Size = new System.Drawing.Size(259, 59);
            this.btnRecieve.TabIndex = 1;
            this.btnRecieve.Text = "Recieve";
            this.btnRecieve.UseVisualStyleBackColor = true;
            // 
            // btnStock
            // 
            this.btnStock.Location = new System.Drawing.Point(12, 12);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(259, 59);
            this.btnStock.TabIndex = 2;
            this.btnStock.Text = "Stock Change";
            this.btnStock.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(11, 272);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(259, 59);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // Materials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 342);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.btnVendor);
            this.Controls.Add(this.btnRecieve);
            this.Controls.Add(this.btnStock);
            this.Name = "Materials";
            this.Text = "Materials";
            this.Load += new System.EventHandler(this.Materials_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button btnVendor;
        private System.Windows.Forms.Button btnRecieve;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnReport;
    }
}