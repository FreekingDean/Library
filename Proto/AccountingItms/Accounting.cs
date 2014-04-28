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

        private void Accounting_Load(object sender, EventArgs e)
        {

        }
    }
}
