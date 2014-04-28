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
    public partial class ManageUser : Form
    {
        public ManageUser()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> command = new Dictionary<string, string>();
            command["top_cmd"] = "admin";
            command["cmd"] = "get_user";
            command["user_id"] = txtUserId.Text;
            string toSend = MSGMultiplexer.mapToJson(command);
            TLSListener.SendMessage(toSend);
            command = TLSListener.ReadMessage();
            if (command["top_cmd"] != "err")
            {
                txtFirstName.Text = command["first_name"];
                txtLastName.Text = command["last_name"];
                txtUsername.Text = command["username"];
                txtRole.Text = command["role"];
            }
        }
    }
}
