namespace Proto
{
    partial class MainMenu
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
            this.btnFC = new System.Windows.Forms.Button();
            this.btnMat = new System.Windows.Forms.Button();
            this.btnAcc = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFC
            // 
            this.btnFC.Location = new System.Drawing.Point(13, 15);
            this.btnFC.Name = "btnFC";
            this.btnFC.Size = new System.Drawing.Size(259, 59);
            this.btnFC.TabIndex = 0;
            this.btnFC.Text = "Front Counter";
            this.btnFC.UseVisualStyleBackColor = true;
            this.btnFC.Click += new System.EventHandler(this.btnFC_Click);
            // 
            // btnMat
            // 
            this.btnMat.Location = new System.Drawing.Point(13, 78);
            this.btnMat.Name = "btnMat";
            this.btnMat.Size = new System.Drawing.Size(259, 59);
            this.btnMat.TabIndex = 0;
            this.btnMat.Text = "Materials";
            this.btnMat.UseVisualStyleBackColor = true;
            this.btnMat.Click += new System.EventHandler(this.btnMat_Click);
            // 
            // btnAcc
            // 
            this.btnAcc.Location = new System.Drawing.Point(13, 143);
            this.btnAcc.Name = "btnAcc";
            this.btnAcc.Size = new System.Drawing.Size(259, 59);
            this.btnAcc.TabIndex = 0;
            this.btnAcc.Text = "Accounting";
            this.btnAcc.UseVisualStyleBackColor = true;
            this.btnAcc.Click += new System.EventHandler(this.btnAcc_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(12, 208);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(259, 59);
            this.btnAdmin.TabIndex = 0;
            this.btnAdmin.Text = "Administration";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(12, 273);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(259, 59);
            this.btnLogOut.TabIndex = 0;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 344);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnAcc);
            this.Controls.Add(this.btnMat);
            this.Controls.Add(this.btnFC);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFC;
        private System.Windows.Forms.Button btnMat;
        private System.Windows.Forms.Button btnAcc;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnLogOut;
    }
}