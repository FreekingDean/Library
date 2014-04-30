﻿using System;
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

        private void ManageUser_Load(object sender, EventArgs e)
        {
            txtPasswordInput.Visible = false;
            txtConformation.Visible = false;
            btnAdd.Text = "Add";
            addMode = true;
        }

        public ManageUser(Form callerForm)
        {
            callbackForm = callerForm;
            InitializeComponent();
        }

        /// <summary>
        /// Allows the user to add or edit a user.  
        /// By default it adds if no user is found.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> command = new Dictionary<string, string>();
            command["top_cmd"] = "admin";
            command["cmd"] = "modify_user";
            if (!addMode )
            {
                command["user_id"] = txtUserId.Text;
                if (txtPasswordInput.Text == txtConformation.Text)
                {
                    command["new_password"] = txtConformation.Text;
                }
                else
                {
                    Error_Msg em = new Error_Msg("Password & confirmation must match", "31001");
                    em.Show();
                    return;
                }
            }

            if (txtUsername.Text.Equals("") || txtPassword.Text.Equals("") || txtRole.Text.Equals("") ||
                txtFirstName.Text.Equals("") || txtLastName.Text.Equals(""))
            {
                return;
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

        /// <summary>
        /// Gets the information from the server and displays it on the form
        /// </summary>
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtUserId.Equals(""))
            {
                return;
            }
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
                btnAdd.Text = "Edit";
                addMode = false;
            }
        }

        /// <summary>
        /// Closes this form and shows the calling form.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            callbackForm.Show();
            this.Close();
        }

        /// <summary>
        /// Deletes a user from the system.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text.Equals("") || txtPassword.Text.Equals(""))
            {
                return;
            }
            Dictionary<string, string> command = new Dictionary<string, string>();
            command["top_cmd"] = "admin";
            command["cmd"] = "delete_user";
            command["user_id"] = txtUserId.Text;
            command["password"] = txtPassword.Text;
            string toSend = MSGMultiplexer.mapToJson(command);
            TLSListener.SendMessage(toSend);
            command = TLSListener.ReadMessage();
            if (command["top_cmd"] == "success")
            {
                callbackForm.Show(); 
                this.Close();
            }
        }
    }
}