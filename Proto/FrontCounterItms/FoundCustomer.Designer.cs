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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnManageCustomer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
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
            this.listBox1.Location = new System.Drawing.Point(17, 16);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(344, 180);
            this.listBox1.TabIndex = 0;
            // 
            // btnManageCustomer
            // 
            this.btnManageCustomer.Location = new System.Drawing.Point(17, 206);
            this.btnManageCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnManageCustomer.Name = "btnManageCustomer";
            this.btnManageCustomer.Size = new System.Drawing.Size(345, 79);
            this.btnManageCustomer.TabIndex = 1;
            this.btnManageCustomer.Text = "Manage Customer";
            this.btnManageCustomer.UseVisualStyleBackColor = true;
            this.btnManageCustomer.Click += new System.EventHandler(this.btnManageCustomer_Click);
            // 
            // FoundCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 299);
            this.Controls.Add(this.btnManageCustomer);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FoundCustomer";
            this.Text = "FoundCustomer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnManageCustomer;
    }
}