using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proto.AccountingItms
{
    public partial class Accounting : Form
    {
        Form callbackForm;
        public Accounting(Form callerForm)
        {
            callbackForm = callerForm;
            InitializeComponent();
        }

        /// <summary>
        /// Opens a new ManageBudgets with this form as the call back.
        /// </summary>
        private void btnBudgets_Click(object sender, EventArgs e)
        {
            ManageBudgets mb = new ManageBudgets(this);
            mb.Show();
            this.Hide();
        }

        /// <summary>
        /// Reverts back to the previous form.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            callbackForm.Show();
            this.Hide();
        }
    }
}
