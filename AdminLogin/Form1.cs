using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminLogin
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void chkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxShowPassword.Checked)
            {
                txtPassword.PasswordChar = char.Parse("\0");
            }
            else
            {
                txtPassword.PasswordChar = char.Parse("*");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void grapesFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Grapes_Form().Show();
        }
    }
}
