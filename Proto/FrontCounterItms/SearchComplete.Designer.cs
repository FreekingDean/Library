namespace Proto.FrontCounter
{
    partial class SearchComplete
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
            this.lstBook = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblISBN = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.btnChangeStock = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBook
            // 
            this.lstBook.FormattingEnabled = true;
            this.lstBook.Items.AddRange(new object[] {
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book",
            "Sample Book"});
            this.lstBook.Location = new System.Drawing.Point(13, 13);
            this.lstBook.Name = "lstBook";
            this.lstBook.Size = new System.Drawing.Size(116, 134);
            this.lstBook.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(135, 17);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(55, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Book Title";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(134, 30);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(38, 13);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "Author";
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(134, 43);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(32, 13);
            this.lblISBN.TabIndex = 2;
            this.lblISBN.Text = "ISBN";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(134, 56);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(47, 13);
            this.lblBarcode.TabIndex = 2;
            this.lblBarcode.Text = "Barcode";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(135, 69);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(97, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Short Description...";
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(379, 8);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(116, 31);
            this.btnCheck.TabIndex = 3;
            this.btnCheck.Text = "Check IN/OUT";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReserve
            // 
            this.btnReserve.Location = new System.Drawing.Point(379, 45);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(116, 31);
            this.btnReserve.TabIndex = 3;
            this.btnReserve.Text = "Reserve";
            this.btnReserve.UseVisualStyleBackColor = true;
            // 
            // btnChangeStock
            // 
            this.btnChangeStock.Location = new System.Drawing.Point(379, 82);
            this.btnChangeStock.Name = "btnChangeStock";
            this.btnChangeStock.Size = new System.Drawing.Size(116, 31);
            this.btnChangeStock.TabIndex = 3;
            this.btnChangeStock.Text = "Change Stock";
            this.btnChangeStock.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(379, 116);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(116, 31);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // SearchComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 159);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnChangeStock);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lstBook);
            this.Name = "SearchComplete";
            this.Text = "SearchComplete";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBook;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Button btnChangeStock;
        private System.Windows.Forms.Button btnBack;
    }
}