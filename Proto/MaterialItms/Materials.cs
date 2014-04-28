using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proto.MaterialItms
{
    public partial class Materials : Form
    {
        Form callbackForm;
        public Materials(Form callerForm)
        {
            callbackForm = callerForm;
            InitializeComponent();
        }

        private void Materials_Load(object sender, EventArgs e)
        {

        }
    }
}
