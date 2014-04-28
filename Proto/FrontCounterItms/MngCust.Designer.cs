namespace Proto.FrontCounterItms
{
    partial class MngCust
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
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCondition = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(12, 12);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(100, 20);
            this.txtFName.TabIndex = 0;
            this.txtFName.Text = "First Name";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(118, 12);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(100, 20);
            this.txtLName.TabIndex = 0;
            this.txtLName.Text = "Last Name";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 38);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(416, 47);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save/Add New";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(224, 12);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(100, 20);
            this.txtCondition.TabIndex = 0;
            this.txtCondition.Text = "Condition";
            this.txtCondition.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(328, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 0;
            this.txtId.Text = "Cust ID";
            this.txtId.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MngCust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 91);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtCondition);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Name = "MngCust";
            this.Text = "MngCust";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCondition;
        private System.Windows.Forms.TextBox txtId;
    }
}