using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proto.FrontCounter
{
    public partial class ManageCustomer : Form
    {
        public ManageCustomer()
        {
            InitializeComponent();
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            FrontCounterItms.MngCust mgc = new FrontCounterItms.MngCust();
            mgc.Show();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}
