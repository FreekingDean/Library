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
    public partial class SearchComplete : Form
    {
        public SearchComplete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBookList())
            {
                return;
            }
            CheckOutBook cob = new CheckOutBook();
            cob.Show();
        }

        /// <summary>
        /// Simple sanity check if a book was selected from the listbox.
        /// </summary>
        /// <returns></returns>
        private Boolean checkBookList()
        {
            return lstBook.SelectedIndex > -1;
        }

        /// <summary>
        /// Simple close sub.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
