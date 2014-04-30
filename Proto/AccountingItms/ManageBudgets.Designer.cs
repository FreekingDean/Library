namespace Proto.AccountingItms
{
    partial class ManageBudgets
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
            this.txtBudgetID = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtLeftInMB = new System.Windows.Forms.TextBox();
            this.txtLeftInBW = new System.Windows.Forms.TextBox();
            this.txtLeftInMW = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBudgetID
            // 
            this.txtBudgetID.Location = new System.Drawing.Point(13, 13);
            this.txtBudgetID.Name = "txtBudgetID";
            this.txtBudgetID.Size = new System.Drawing.Size(100, 20);
            this.txtBudgetID.TabIndex = 0;
            this.txtBudgetID.Text = "Budget ID";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(13, 39);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAmount.TabIndex = 0;
            this.txtTotalAmount.Text = "Total Amount";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(13, 79);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(94, 79);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add/Edit";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(175, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(256, 79);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // txtLeftInMB
            // 
            this.txtLeftInMB.Location = new System.Drawing.Point(122, 13);
            this.txtLeftInMB.Name = "txtLeftInMB";
            this.txtLeftInMB.Size = new System.Drawing.Size(100, 20);
            this.txtLeftInMB.TabIndex = 3;
            this.txtLeftInMB.Text = "Left In Master Budget";
            // 
            // txtLeftInBW
            // 
            this.txtLeftInBW.Location = new System.Drawing.Point(122, 39);
            this.txtLeftInBW.Name = "txtLeftInBW";
            this.txtLeftInBW.Size = new System.Drawing.Size(100, 20);
            this.txtLeftInBW.TabIndex = 3;
            this.txtLeftInBW.Text = "Left In Budget Wallet";
            // 
            // txtLeftInMW
            // 
            this.txtLeftInMW.Location = new System.Drawing.Point(228, 12);
            this.txtLeftInMW.Name = "txtLeftInMW";
            this.txtLeftInMW.Size = new System.Drawing.Size(100, 20);
            this.txtLeftInMW.TabIndex = 3;
            this.txtLeftInMW.Text = "Left In Master Wallet";
            // 
            // ManageBudgets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 110);
            this.Controls.Add(this.txtLeftInMW);
            this.Controls.Add(this.txtLeftInBW);
            this.Controls.Add(this.txtLeftInMB);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtBudgetID);
            this.Name = "ManageBudgets";
            this.Text = "ManageBudgets";
            this.Load += new System.EventHandler(this.ManageBudgets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBudgetID;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtLeftInMB;
        private System.Windows.Forms.TextBox txtLeftInBW;
        private System.Windows.Forms.TextBox txtLeftInMW;

    }
}