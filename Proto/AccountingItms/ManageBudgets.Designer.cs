﻿namespace Proto.AccountingItms
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
            this.txtTotalAmount.Location = new System.Drawing.Point(13, 65);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalAmount.TabIndex = 0;
            this.txtTotalAmount.Text = "Total Amount";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(12, 169);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(93, 169);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add/Edit";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 169);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(254, 169);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtLeftInMB
            // 
            this.txtLeftInMB.Enabled = false;
            this.txtLeftInMB.Location = new System.Drawing.Point(12, 117);
            this.txtLeftInMB.Name = "txtLeftInMB";
            this.txtLeftInMB.Size = new System.Drawing.Size(100, 20);
            this.txtLeftInMB.TabIndex = 3;
            this.txtLeftInMB.Text = "Left In Master Budget";
            // 
            // txtLeftInBW
            // 
            this.txtLeftInBW.Enabled = false;
            this.txtLeftInBW.Location = new System.Drawing.Point(13, 91);
            this.txtLeftInBW.Name = "txtLeftInBW";
            this.txtLeftInBW.Size = new System.Drawing.Size(100, 20);
            this.txtLeftInBW.TabIndex = 3;
            this.txtLeftInBW.Text = "Left In Budget Wallet";
            // 
            // txtLeftInMW
            // 
            this.txtLeftInMW.Enabled = false;
            this.txtLeftInMW.Location = new System.Drawing.Point(13, 143);
            this.txtLeftInMW.Name = "txtLeftInMW";
            this.txtLeftInMW.Size = new System.Drawing.Size(100, 20);
            this.txtLeftInMW.TabIndex = 3;
            this.txtLeftInMW.Text = "Left In Master Wallet";
            // 
            // txtBudgetName
            // 
            this.txtBudgetName.Location = new System.Drawing.Point(13, 39);
            this.txtBudgetName.Name = "txtBudgetName";
            this.txtBudgetName.Size = new System.Drawing.Size(100, 20);
            this.txtBudgetName.TabIndex = 0;
            this.txtBudgetName.Text = "Budget Name";
            // 
            // ManageBudgets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 206);
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

    }
}