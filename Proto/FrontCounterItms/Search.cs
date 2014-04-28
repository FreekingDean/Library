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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtKeyWord.Text.Equals("") || cmbField.SelectedIndex == -1)
            {
                return;
            }
            SearchComplete sc = new SearchComplete();
            sc.Show();
        }

        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
