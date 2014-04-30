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
        Form callBackFrom;
        public ManageBudgets(Form callerForm)
        {
            InitializeComponent();
            callBackFrom = callerForm;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBudgetID.Text == "")
            {
                Error_Msg em = new Error_Msg("15002", "Please enter a budget ID.");
            }
            Dictionary<string, string> command = new Dictionary<string, string>();
            command["top_cmd"] = "admin";
            command["cmd"] = "get_budget";

        }

        private void ManageBudgets_Load(object sender, EventArgs e)
        {
            btnAdd.Text = "Add";
            addMode = true;
            Dictionary<string, string> getBudget = new Dictionary<string, string>();
            getBudget["top_cmd"] = "admin";
            getBudget["cmd"] = "get_budget";
            Dictionary<string, string> getWallet = new Dictionary<string, string>();
            getWallet["top_cmd"] = "admin";
            getWallet["cmd"] = "get_wallet";
            string toSend = MSGMultiplexer.mapToJson(getBudget);
            TLSListener.SendMessage(toSend);
            getBudget = TLSListener.ReadMessage();
            toSend = MSGMultiplexer.mapToJson(getWallet);
            TLSListener.SendMessage(toSend);
            getWallet = TLSListener.ReadMessage();
            if (getWallet["top_cmd"] == "err" || getBudget["top_cmd"] == "err")
            {
                Error_Msg em = new Error_Msg("15001", "Can't open wallet please try again.");
                em.Show();
                callBackFrom.Show();
                this.Close();
                return;
            }
            txtLeftInMB.Text = getBudget["budget_left"];
            txtLeftInMW.Text = getWallet["amount_left"];
        }
    }
}
