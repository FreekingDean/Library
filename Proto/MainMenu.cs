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
        FrontCounter.FrontCounter fcMenu;
        MaterialItms.Materials matMenu;
        AccountingItms.Accounting accMenu;
        AdminItms.Admin adMenu;
        public MainMenu(int role)
        {
            fcMenu = new FrontCounter.FrontCounter(this);
            matMenu = new MaterialItms.Materials(this);
            accMenu = new AccountingItms.Accounting(this);
            adMenu = new AdminItms.Admin(this);
            userRole = role;
            InitializeComponent();
        }

        /// <summary>
        /// Opens front counter GUI.
        /// </summary>
        private void btnFC_Click(object sender, EventArgs e)
        {
            this.Hide();
            fcMenu.Show(this);
        }

        private void btnMat_Click(object sender, EventArgs e)
        {
            this.Hide();
            matMenu.Show();
        }

        private void btnAcc_Click(object sender, EventArgs e)
        {
            this.Hide();
            accMenu.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.Hide();
            adMenu.Show();
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
    }
}
