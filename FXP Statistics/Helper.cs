using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FXP_Statistics
{
    class Helper
    {
        public bool isGUI = true;
        public void AddTextLog(string text)
        {
            if (isGUI)
            {
                SplitContainer splitContainer = (SplitContainer)Application.OpenForms["Form1"].Controls["splitContainer1"];
                System.Windows.Forms.TextBox txtLogs = splitContainer.Panel2.Controls["txtLog"] as System.Windows.Forms.TextBox;
                txtLogs.Text = txtLogs.Text + text;
            }
            else
                Console.WriteLine(text);
        }

        public void ClearTextLog()
        {
            SplitContainer splitContainer = (SplitContainer)Application.OpenForms["Form1"].Controls["splitContainer1"];
            System.Windows.Forms.TextBox txtLogs = splitContainer.Panel2.Controls["txtLog"] as System.Windows.Forms.TextBox;
            txtLogs.Text = "";
        }

        public void EnableGetStatsButton()
        {
            if (isGUI)
            {
                SplitContainer splitContainer = (SplitContainer)Application.OpenForms["Form1"].Controls["splitContainer1"];
                System.Windows.Forms.Button btnGetStats = splitContainer.Panel1.Controls["btnGetStats"] as System.Windows.Forms.Button;
                btnGetStats.Enabled = true;
            }
        }

        public int GetNumberOfDays()
        {
            int numberOfDays = 7;
            if (isGUI)
            {
                SplitContainer splitContainer = (SplitContainer)Application.OpenForms["Form1"].Controls["splitContainer1"];
                System.Windows.Forms.TextBox txtNumberOfDays = splitContainer.Panel1.Controls["txtNumOfDays"] as System.Windows.Forms.TextBox;
                Int32.TryParse(txtNumberOfDays.Text, out numberOfDays);
                return numberOfDays;
            }
            return numberOfDays;
        }
    }
}
