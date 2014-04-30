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

        private void btnFC_Click(object sender, EventArgs e)
        {
            ManageBudgets mb = new ManageBudgets(this);
            mb.Show();
            this.Hide();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            callbackForm.Show();
            this.Hide();
        }
    }
}
