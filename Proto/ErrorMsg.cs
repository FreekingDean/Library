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
    public partial class Error_Msg : Form
    {
        string errCode = "";
        string errMsg = "";
        public Error_Msg(string code, string msg)
        {
            errCode = code;
            errMsg = msg;
            InitializeComponent();
        }

        private void Error_Msg_Load(object sender, EventArgs e)
        {
            err_lbl.Text = errCode;
            msg_lbl.Text = errMsg;
        }
    }
}
