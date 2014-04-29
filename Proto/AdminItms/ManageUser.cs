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
        Form callbackForm;
        bool addMode;
        public ManageUser(Form callerForm)
        {
            callbackForm = callerForm;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> command = new Dictionary<string, string>();
            command["top_cmd"] = "admin";
            command["cmd"] = "modify_user";
            if (!addMode )
            {
                command["user_id"] = txtUserId.Text;
            }
            command["username"] = txtUsername.Text;
            command["password"] = txtPassword.Text;
            command["role"] = txtRole.Text;
            command["first_name"] = txtFirstName.Text;
            command["last_name"] = txtLastName.Text;
            string toSend = MSGMultiplexer.mapToJson(command);
            TLSListener.SendMessage(toSend);
            command = TLSListener.ReadMessage();
            if (command["top_cmd"] == "success")
            {
                callbackForm.Show();
                this.Close();
            }

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
            if (command["top_cmd"] != "error")
            {
                txtFirstName.Text = command["first_name"];
                txtLastName.Text = command["last_name"];
                txtUsername.Text = command["username"];
                txtRole.Text = command["role"];
                txtPasswordInput.Visible = true;
                txtConformation.Visible = true;
                button2.Text = "Edit";
                addMode = false;
            }
        }

        private void ManageUser_Load(object sender, EventArgs e)
        {
            txtPasswordInput.Visible = false;
            txtConformation.Visible = false;
            button2.Text = "Add";
            addMode = true;
        }
    }
}
