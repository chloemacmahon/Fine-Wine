using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Selection
{
    public partial class SelectionPage : Form
    {
        public SelectionPage()
        {
            InitializeComponent();
        }


        private void btnWines_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.Hide();
                Wines w1 = new Wines();
                w1.ShowDialog();
            }

            else if (radioButton2.Checked)
            {
                this.Hide();
                Wines w2 = new Wines();
                w2.ShowDialog();
            }

            else if (radioButton3.Checked)
            {
                this.Hide();
                Wines w3 = new Wines();
                w3.ShowDialog();
            }

            else
            {
                DialogResult _close = MessageBox.Show("Please make a selection!", "Invalid Choice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (_close == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void btnGrapes_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                this.Hide();
                Grapes g1 = new Grapes();
                g1.ShowDialog();
            }

            else if (radioButton5.Checked)
            {
                this.Hide();
                Grapes g2 = new Grapes();
                g2.ShowDialog();
            }

            else
            {
                DialogResult _close = MessageBox.Show("Please make a selection!", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (_close == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void btnClearWines_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
        }

        private void btnCLearGrapes_Click(object sender, EventArgs e)
        {
            radioButton4.Checked = false;
            radioButton5.Checked = false;
        }
    }
}
