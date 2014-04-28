namespace Proto
{
    partial class Error_Msg
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
            this.err_lbl = new System.Windows.Forms.Label();
            this.msg_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // err_lbl
            // 
            this.err_lbl.AutoSize = true;
            this.err_lbl.Location = new System.Drawing.Point(53, 9);
            this.err_lbl.Name = "err_lbl";
            this.err_lbl.Size = new System.Drawing.Size(35, 13);
            this.err_lbl.TabIndex = 0;
            this.err_lbl.Text = "label1";
            // 
            // msg_lbl
            // 
            this.msg_lbl.AutoSize = true;
            this.msg_lbl.Location = new System.Drawing.Point(12, 9);
            this.msg_lbl.Name = "msg_lbl";
            this.msg_lbl.Size = new System.Drawing.Size(35, 13);
            this.msg_lbl.TabIndex = 1;
            this.msg_lbl.Text = "label1";
            // 
            // Error_Msg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 30);
            this.Controls.Add(this.msg_lbl);
            this.Controls.Add(this.err_lbl);
            this.Name = "Error_Msg";
            this.Text = "Error!";
            this.Load += new System.EventHandler(this.Error_Msg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label err_lbl;
        private System.Windows.Forms.Label msg_lbl;
    }
}