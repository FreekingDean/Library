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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtLeftInMB = new System.Windows.Forms.TextBox();
            this.txtLeftInBW = new System.Windows.Forms.TextBox();
            this.txtLeftInMW = new System.Windows.Forms.TextBox();
            this.txtBudgetName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBudgetID
            // 
            this.txtBudgetID.Location = new System.Drawing.Point(16, 30);
            this.txtBudgetID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBudgetID.Name = "txtBudgetID";
            this.txtBudgetID.Size = new System.Drawing.Size(175, 22);
            this.txtBudgetID.TabIndex = 0;
            this.txtBudgetID.Text = "Budget ID";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(16, 124);
            this.txtTotalAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(175, 22);
            this.txtTotalAmount.TabIndex = 0;
            this.txtTotalAmount.Text = "Total Amount";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(16, 208);
            this.btnGet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(100, 28);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(124, 208);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add/Edit";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(232, 208);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(339, 208);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 28);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtLeftInMB
            // 
            this.txtLeftInMB.Enabled = false;
            this.txtLeftInMB.Location = new System.Drawing.Point(232, 30);
            this.txtLeftInMB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLeftInMB.Name = "txtLeftInMB";
            this.txtLeftInMB.Size = new System.Drawing.Size(175, 22);
            this.txtLeftInMB.TabIndex = 3;
            this.txtLeftInMB.Text = "Left In Master Budget";
            // 
            // txtLeftInBW
            // 
            this.txtLeftInBW.Enabled = false;
            this.txtLeftInBW.Location = new System.Drawing.Point(16, 171);
            this.txtLeftInBW.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLeftInBW.Name = "txtLeftInBW";
            this.txtLeftInBW.Size = new System.Drawing.Size(175, 22);
            this.txtLeftInBW.TabIndex = 3;
            this.txtLeftInBW.Text = "Left In Budget Wallet";
            // 
            // txtLeftInMW
            // 
            this.txtLeftInMW.Enabled = false;
            this.txtLeftInMW.Location = new System.Drawing.Point(232, 77);
            this.txtLeftInMW.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLeftInMW.Name = "txtLeftInMW";
            this.txtLeftInMW.Size = new System.Drawing.Size(175, 22);
            this.txtLeftInMW.TabIndex = 3;
            this.txtLeftInMW.Text = "Left In Master Wallet";
            // 
            // txtBudgetName
            // 
            this.txtBudgetName.Location = new System.Drawing.Point(16, 77);
            this.txtBudgetName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBudgetName.Name = "txtBudgetName";
            this.txtBudgetName.Size = new System.Drawing.Size(175, 22);
            this.txtBudgetName.TabIndex = 0;
            this.txtBudgetName.Text = "Budget Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total Amount:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Total Amount:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(229, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Remaining Budget:";
            // 
            // ManageBudgets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 254);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLeftInMW);
            this.Controls.Add(this.txtLeftInBW);
            this.Controls.Add(this.txtLeftInMB);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.txtBudgetName);
            this.Controls.Add(this.txtBudgetID);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtLeftInMB;
        private System.Windows.Forms.TextBox txtLeftInBW;
        private System.Windows.Forms.TextBox txtLeftInMW;
        private System.Windows.Forms.TextBox txtBudgetName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

    }
}