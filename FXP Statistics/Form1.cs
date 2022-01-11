using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FXP_Statistics
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtNumOfDays.KeyPress += TxtNumOfDays_KeyPress;
            txtNumOfDays.TextChanged += TxtNumOfDays_TextChanged;
        }

        private void TxtNumOfDays_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumOfDays.Text))
            {
                int numText = 0;
                Int32.TryParse(txtNumOfDays.Text, out numText);
                if (numText <= 1)
                    txtNumOfDays.Text = "1";
                if (numText >= 7)
                    txtNumOfDays.Text = "7";
            }
        }

        private void TxtNumOfDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') >= -1))
            {
                e.Handled = true;
            }
        }

        private void btnGetStats_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumOfDays.Text))
                txtNumOfDays.Text = "7";
            btnGetStats.Enabled = false;
            Parser parser = new Parser();
            parser.GetForumThreads(txtForumNum.Text, 1);
        }
    }
}
