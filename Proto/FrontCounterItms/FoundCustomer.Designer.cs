namespace Proto.FrontCounter
{
    partial class FoundCustomer
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
            this.lstCustomer = new System.Windows.Forms.ListBox();
            this.btnManageCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstCustomer
            // 
            this.lstCustomer.FormattingEnabled = true;
            this.lstCustomer.Items.AddRange(new object[] {
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number",
            "Cust Name, Phone, Address, ID Number"});
            this.lstCustomer.Location = new System.Drawing.Point(13, 13);
            this.lstCustomer.Name = "lstCustomer";
            this.lstCustomer.Size = new System.Drawing.Size(259, 147);
            this.lstCustomer.TabIndex = 0;
            // 
            // btnManageCustomer
            // 
            this.btnManageCustomer.Location = new System.Drawing.Point(13, 167);
            this.btnManageCustomer.Name = "btnManageCustomer";
            this.btnManageCustomer.Size = new System.Drawing.Size(259, 64);
            this.btnManageCustomer.TabIndex = 1;
            this.btnManageCustomer.Text = "Manage Customer";
            this.btnManageCustomer.UseVisualStyleBackColor = true;
            this.btnManageCustomer.Click += new System.EventHandler(this.btnManageCustomer_Click);
            // 
            // FoundCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 243);
            this.Controls.Add(this.btnManageCustomer);
            this.Controls.Add(this.lstCustomer);
            this.Name = "FoundCustomer";
            this.Text = "FoundCustomer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstCustomer;
        private System.Windows.Forms.Button btnManageCustomer;
    }
}