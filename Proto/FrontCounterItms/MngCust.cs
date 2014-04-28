using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proto.FrontCounterItms
{
    public partial class MngCust : Form
    {
        public MngCust()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles sanity checks for 
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text.Equals("")||txtEmail.Text .Equals ("")||txtCity.Text .Equals ("")||
            txtFName .Text .Equals ("")||txtLName.Text .Equals ("")||txtPhone .Text .Equals ("")
            ||txtState .Text .Equals ("")||txtZip .Text .Equals (""))
            {
                return;
            }

            //code here
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
