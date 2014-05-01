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
        Form callbackForm;
        public Admin(Form callerForm)
        {
            callbackForm = callerForm;
            InitializeComponent();
        }

        /// <summary>
        /// Opens up the Manage User Form with this as the call back form.
        /// </summary>
        private void btnMngUser_Click(object sender, EventArgs e)
        {
            ManageUser userForm = new ManageUser(this);
            this.Hide();
            userForm.Show();
        }

        /// <summary>
        /// Sends the restore command to the server.
        /// </summary>
        private void btnRestore_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> backup = new Dictionary<string, string>();
            backup["top_cmd"] = "admin";
            backup["cmd"] = "restore_system";
            string toSend = MSGMultiplexer.mapToJson(backup);
            TLSListener.SendMessage(toSend);
        }

        /// <summary>
        /// Sends the backup command to the server
        /// </summary>
        private void btnBackup_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> backup = new Dictionary<string, string>();
            backup["top_cmd"] = "admin";
            backup["cmd"] = "backup_system";
            string toSend = MSGMultiplexer.mapToJson(backup);
            TLSListener.SendMessage(toSend);
        }

        /// <summary>
        /// Goes back to the calling form
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            callbackForm.Show();
        }
    }
}
