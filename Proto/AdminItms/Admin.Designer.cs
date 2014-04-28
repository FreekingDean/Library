namespace Proto.AdminItms
{
    partial class Admin
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
            this.btnGoBack = new System.Windows.Forms.Button();
            this.btnVendor = new System.Windows.Forms.Button();
            this.btnRecieve = new System.Windows.Forms.Button();
            this.btnMngUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGoBack
            // 
            this.btnGoBack.Location = new System.Drawing.Point(13, 207);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(259, 59);
            this.btnGoBack.TabIndex = 9;
            this.btnGoBack.Text = "Go Back";
            this.btnGoBack.UseVisualStyleBackColor = true;
            // 
            // btnVendor
            // 
            this.btnVendor.Location = new System.Drawing.Point(13, 142);
            this.btnVendor.Name = "btnVendor";
            this.btnVendor.Size = new System.Drawing.Size(259, 59);
            this.btnVendor.TabIndex = 8;
            this.btnVendor.Text = "Restore";
            this.btnVendor.UseVisualStyleBackColor = true;
            this.btnVendor.Click += new System.EventHandler(this.btnVendor_Click);
            // 
            // btnRecieve
            // 
            this.btnRecieve.Location = new System.Drawing.Point(13, 77);
            this.btnRecieve.Name = "btnRecieve";
            this.btnRecieve.Size = new System.Drawing.Size(259, 59);
            this.btnRecieve.TabIndex = 6;
            this.btnRecieve.Text = "Backup";
            this.btnRecieve.UseVisualStyleBackColor = true;
            this.btnRecieve.Click += new System.EventHandler(this.btnRecieve_Click);
            // 
            // btnMngUser
            // 
            this.btnMngUser.Location = new System.Drawing.Point(13, 12);
            this.btnMngUser.Name = "btnMngUser";
            this.btnMngUser.Size = new System.Drawing.Size(259, 59);
            this.btnMngUser.TabIndex = 7;
            this.btnMngUser.Text = "Manage User";
            this.btnMngUser.UseVisualStyleBackColor = true;
            this.btnMngUser.Click += new System.EventHandler(this.btnMngUser_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 271);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnVendor);
            this.Controls.Add(this.btnRecieve);
            this.Controls.Add(this.btnMngUser);
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Button btnVendor;
        private System.Windows.Forms.Button btnRecieve;
        private System.Windows.Forms.Button btnMngUser;
    }
}