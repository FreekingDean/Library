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
            this.btnAcc = new System.Windows.Forms.Button();
            this.btnMat = new System.Windows.Forms.Button();
            this.btnFC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAcc
            // 
            this.btnAcc.Location = new System.Drawing.Point(13, 141);
            this.btnAcc.Name = "btnAcc";
            this.btnAcc.Size = new System.Drawing.Size(259, 59);
            this.btnAcc.TabIndex = 3;
            this.btnAcc.Text = "Back";
            this.btnAcc.UseVisualStyleBackColor = true;
            // 
            // btnMat
            // 
            this.btnMat.Location = new System.Drawing.Point(13, 76);
            this.btnMat.Name = "btnMat";
            this.btnMat.Size = new System.Drawing.Size(259, 59);
            this.btnMat.TabIndex = 4;
            this.btnMat.Text = "Manage Wallets";
            this.btnMat.UseVisualStyleBackColor = true;
            // 
            // btnFC
            // 
            this.btnFC.Location = new System.Drawing.Point(13, 13);
            this.btnFC.Name = "btnFC";
            this.btnFC.Size = new System.Drawing.Size(259, 59);
            this.btnFC.TabIndex = 5;
            this.btnFC.Text = "Manage Budgets";
            this.btnFC.UseVisualStyleBackColor = true;
            // 
            // Accounting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 209);
            this.Controls.Add(this.btnAcc);
            this.Controls.Add(this.btnMat);
            this.Controls.Add(this.btnFC);
            this.Name = "Accounting";
            this.Text = "Accounting";
            this.Load += new System.EventHandler(this.Accounting_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAcc;
        private System.Windows.Forms.Button btnMat;
        private System.Windows.Forms.Button btnFC;
    }
}