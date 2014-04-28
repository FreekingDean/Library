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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the login sanity checks, and makes call to server.
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtIp1.Text.Equals("") || txtIp2.Text.Equals("") || txtIp3.Text.Equals("") || txtIp4.Text.Equals("") 
            || txtPort.Text.Equals("") || txtUser.Text.Equals("") || txtPasscode.Text.Equals(""))
            {
                Error_Msg em = new Error_Msg("Please input all address info to connect", "10001");
                em.Show();
                //return;
            }
            //TLSListener.RunClient(txtIp1.Text + "." + txtIp2.Text + "." + txtIp3.Text + "." + txtIp4.Text, Int32.Parse(txtPort.Text));
            TLSListener.RunClient("150.250.222.170", 8000);
            Dictionary<string, string> login = new Dictionary<string, string>();
            login["top_cmd"] = "login";
            login["username"] = txtUser.Text;
            login["password"] = txtPasscode.Text;
            string toSend = MSGMultiplexer.mapToJson(login);
            Console.WriteLine(toSend);
            TLSListener.SendMessage(toSend);
            login = TLSListener.ReadMessage();
            login["top_cmd"] = "admin";
            login["cmd"] = "backup_system";
            login["password"] = txtPasscode.Text;
            toSend = MSGMultiplexer.mapToJson(login);
            Console.WriteLine(toSend);
            TLSListener.SendMessage(toSend);
            login = TLSListener.ReadMessage();
            if (login["top_cmd"] == "logged_in")
            {
                MainMenu mm = new MainMenu(Int32.Parse(login["role"]));
                this.Hide();
                mm.Show();
            }
        }

        /// <summary>
        /// Very simple exit function.
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        /// <summary>
        /// Limits textboxes txtIp1,txtIp2,txtIp3,txtIp4 to just numbers.
        /// </summary>
        private void textChangedIP(object sender, System.Windows.Forms.KeyPressEventArgs e) 
        {
            TextBox tb = sender as TextBox;
            int numChar = e.KeyChar;
            //Use ascii table numbers to filter out letters (8 = backspace)
            if (((numChar < 48 || numChar > 57) && numChar != 8) || (numChar != 8 && tb.Text.Length >= 3))
            {
                Console.WriteLine(tb.Text);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Limits textboxes txtPort to just numbers.
        /// </summary>
        private void textChangedPort(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            int numChar = e.KeyChar;
            //Use ascii table numbers to filter out letters (8 = backspace)
            if (((numChar < 48 || numChar > 57) && numChar != 8) || (numChar != 8 && tb.Text.Length >= 8))
            {
                Console.WriteLine(tb.Text);
                e.Handled = true;
            }
        }
    }
}
