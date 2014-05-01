namespace Proto.AccountingItms
{
    partial class Accounting
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnWallets = new System.Windows.Forms.Button();
            this.btnBudgets = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(17, 174);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(345, 73);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnWallets
            // 
            this.btnWallets.Location = new System.Drawing.Point(17, 94);
            this.btnWallets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWallets.Name = "btnWallets";
            this.btnWallets.Size = new System.Drawing.Size(345, 73);
            this.btnWallets.TabIndex = 4;
            this.btnWallets.Text = "Manage Wallets";
            this.btnWallets.UseVisualStyleBackColor = true;
            // 
            // btnBudgets
            // 
            this.btnBudgets.Location = new System.Drawing.Point(17, 17);
            this.btnBudgets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBudgets.Name = "btnBudgets";
            this.btnBudgets.Size = new System.Drawing.Size(345, 73);
            this.btnBudgets.TabIndex = 5;
            this.btnBudgets.Text = "Manage Budgets";
            this.btnBudgets.UseVisualStyleBackColor = true;
            this.btnBudgets.Click += new System.EventHandler(this.btnBudgets_Click);
            // 
            // Accounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 257);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnWallets);
            this.Controls.Add(this.btnBudgets);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Accounting";
            this.Text = "Accounting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnWallets;
        private System.Windows.Forms.Button btnBudgets;
    }
}