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
    public partial class FrontCounter : Form
    {
        Form callebackForm;
        public FrontCounter(Form callerForm)
        {
            callebackForm = callerForm;
            InitializeComponent();
        }

        /// <summary>
        /// Opens up the book management form
        /// </summary>
        private void btnManageBook_Click(object sender, EventArgs e)
        {
            CheckOutBook cob = new CheckOutBook();
            cob.Show();
        }

        /// <summary>
        /// Opens up the search form
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search sc = new Search();
            sc.Show();
        }

        /// <summary>
        /// Opens up the customer management form
        /// </summary>
        private void btnManageCustomer_Click(object sender, EventArgs e)
        {
            ManageCustomer mc = new ManageCustomer();
            mc.Show();
        }

        private void FrontCounter_Load(object sender, EventArgs e)
        {

        }
    }
}
