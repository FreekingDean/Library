using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proto
{
    public partial class MainMenu : Form
    {
        int userRole;
        public MainMenu(int role)
        {
            userRole = role;
            InitializeComponent();
        }

        /// <summary>
        /// Opens front counter GUI.
        /// </summary>
        private void btnFC_Click(object sender, EventArgs e)
        {
            FrontCounter.FrontCounter fc = new FrontCounter.FrontCounter();
            this.Hide();
            fc.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            TLSListener.Close();
            Application.Exit();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            switch (userRole)
            {
                case 1:
                    btnAdmin.Enabled = false;
                    break;
                case 2:
                    btnAdmin.Enabled = false;
                    btnAcc.Enabled = false;
                    break;
                case 3:
                    btnAdmin.Enabled = false;
                    btnAcc.Enabled = false;
                    btnMat.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void btnMat_Click(object sender, EventArgs e)
        {
            MaterialItms.Materials matMenu = new MaterialItms.Materials();
            this.Hide();
            matMenu.Show();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            AccountingItms.Accounting accMenu = new AccountingItms.Accounting();
            this.Hide();
            accMenu.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminItms.Admin adMenu = new AdminItms.Admin();
            this.Hide();
            adMenu.Show();
        }
    }
}
