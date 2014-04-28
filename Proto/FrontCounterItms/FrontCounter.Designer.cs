namespace Proto.FrontCounter
{
    partial class FrontCounter
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
            this.btnManageBook = new System.Windows.Forms.Button();
            this.btnManageCustomer = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageBook
            // 
            this.btnManageBook.Location = new System.Drawing.Point(12, 12);
            this.btnManageBook.Name = "btnManageBook";
            this.btnManageBook.Size = new System.Drawing.Size(260, 59);
            this.btnManageBook.TabIndex = 1;
            this.btnManageBook.Text = "Manage Book";
            this.btnManageBook.UseVisualStyleBackColor = true;
            this.btnManageBook.Click += new System.EventHandler(this.btnManageBook_Click);
            // 
            // btnManageCustomer
            // 
            this.btnManageCustomer.Location = new System.Drawing.Point(12, 142);
            this.btnManageCustomer.Name = "btnManageCustomer";
            this.btnManageCustomer.Size = new System.Drawing.Size(260, 59);
            this.btnManageCustomer.TabIndex = 1;
            this.btnManageCustomer.Text = "Manage Customer";
            this.btnManageCustomer.UseVisualStyleBackColor = true;
            this.btnManageCustomer.Click += new System.EventHandler(this.btnManageCustomer_Click);
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(12, 207);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(260, 59);
            this.btnReports.TabIndex = 1;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 77);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(260, 59);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrontCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 278);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnManageCustomer);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnManageBook);
            this.Name = "FrontCounter";
            this.Text = "FrontCounter";
            this.Load += new System.EventHandler(this.FrontCounter_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageBook;
        private System.Windows.Forms.Button btnManageCustomer;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnSearch;
    }
}