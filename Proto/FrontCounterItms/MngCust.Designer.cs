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
            this.txtFName.Location = new System.Drawing.Point(16, 15);
            this.txtFName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(132, 22);
            this.txtFName.TabIndex = 0;
            this.txtFName.Text = "First Name";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(157, 15);
            this.txtLName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(132, 22);
            this.txtLName.TabIndex = 0;
            this.txtLName.Text = "Last Name";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(16, 47);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(555, 58);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save/Add New";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCondition
            // 
            this.txtCondition.Location = new System.Drawing.Point(299, 15);
            this.txtCondition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCondition.Name = "txtCondition";
            this.txtCondition.Size = new System.Drawing.Size(132, 22);
            this.txtCondition.TabIndex = 0;
            this.txtCondition.Text = "Condition";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(437, 15);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(132, 22);
            this.txtId.TabIndex = 0;
            this.txtId.Text = "Cust ID";
            // 
            // MngCust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 112);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtCondition);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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