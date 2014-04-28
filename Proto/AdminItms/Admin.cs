using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proto.AdminItms
{
    public partial class Admin : Form
    {
        Form userForm;
        Form callbackForm;
        public Admin(Form callerForm)
        {
            callbackForm = callerForm;
            InitializeComponent();
        }

        private void btnMngUser_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            callbackForm.Show();
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> backup = new Dictionary<string, string>();
            backup["top_cmd"] = "admin";
            backup["cmd"] = "restore_system";
            string toSend = MSGMultiplexer.mapToJson(backup);
            TLSListener.SendMessage(toSend);
        }

        private void btnRecieve_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> backup = new Dictionary<string, string>();
            backup["top_cmd"] = "admin";
            backup["cmd"] = "backup_system";
            string toSend = MSGMultiplexer.mapToJson(backup);
            TLSListener.SendMessage(toSend);
        }
    }
}
