using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proto.AccountingItms
{
    public partial class ManageBudgets : Form
    {
        bool addMode;
        Form callBackForm;
        string originalAmount;
        public ManageBudgets(Form callerForm)
        {
            InitializeComponent();
            callBackForm = callerForm;

        }

        /// <summary>
        /// Gets the requested budget from the server.
        /// </summary>
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (txtBudgetID.Text.Equals(""))
            {
                Error_Msg em = new Error_Msg("15002", "Please enter a budget ID.");
            }
            Dictionary<string, string> command = new Dictionary<string, string>();
            command["top_cmd"] = "accounting";
            command["cmd"] = "get_budget";
            command["budget_id"] = txtBudgetID.Text;
            string toSend = MSGMultiplexer.mapToJson(command);
            TLSListener.SendMessage(toSend);
            command = TLSListener.ReadMessage();
            if (command["top_cmd"] != "error")
            {
                txtBudgetName.Text = command["name"];
                txtTotalAmount.Text = command["amount"];
                txtLeftInBW.Text = command["wallet_running_total"];
                addMode = false;
                btnAdd.Text = "Edit";
            }
        }

        /// <summary>
        /// Loads the form and sets the basic functionality
        /// like btnAdd in add mode, and the top level commands for interacting with the server.
        /// </summary>
        private void ManageBudgets_Load(object sender, EventArgs e)
        {
            btnAdd.Text = "Add";
            addMode = true;
            Dictionary<string, string> command = new Dictionary<string, string>();
            command["top_cmd"] = "accounting";
            command["cmd"] = "get_budget";
            string toSend = MSGMultiplexer.mapToJson(command);
            TLSListener.SendMessage(toSend);
            command = TLSListener.ReadMessage();
            if (command["top_cmd"] == "error")
            {
                Error_Msg em = new Error_Msg("15001", "Can't open budget please try again.");
                em.Show();
                callBackForm.Show();
                this.Close();
                return;
            }
            txtLeftInMB.Text = command["remaining"];
            txtLeftInMW.Text = command["wallet_running_total"];
        }

        /// <summary>
        /// Adds a new budget item to the server.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> command = new Dictionary<string, string>();
            command["top_cmd"] = "accounting";
            command["cmd"] = "manage_budget";
            command["group_name"] = txtBudgetName.Text;
            command["budget_amount"] = txtTotalAmount.Text;
            if (!addMode)
            {
                command["budget_id"] = txtBudgetID.Text;
            }
            string toSend = MSGMultiplexer.mapToJson(command);
            TLSListener.SendMessage(toSend);
            command = TLSListener.ReadMessage();
            if (command["top_cmd"] == "success")
            {
                callBackForm.Show();
                this.Close();
            }
        }

        /// <summary>
        /// Deletes a budget from the system.
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> command = new Dictionary<string, string>();
            command["top_cmd"] = "accounting";
            command["cmd"] = "delete_budget";
            command["budget_id"] = txtBudgetID.Text;
            string toSend = MSGMultiplexer.mapToJson(command);
            TLSListener.SendMessage(toSend);
            command = TLSListener.ReadMessage();
            if (command["top_command"] == "success")
            {
                callBackForm.Show();
                this.Close();
            }
        }

        /// <summary>
        /// Returns back to the calling form.
        /// </summary>
        private void btnBack_Click(object sender, EventArgs e)
        {
            callBackForm.Show();
            this.Close();
        }
    }
}
