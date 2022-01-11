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
                System.Windows.Forms.TextBox txtLogs = Application.OpenForms["Form1"].Controls["txtLog"] as System.Windows.Forms.TextBox;
                txtLogs.Text = txtLogs.Text + text;
            }
            else
                Console.WriteLine(text);
        }

        public void ClearTextLog()
        {
            System.Windows.Forms.TextBox txtLogs = Application.OpenForms["Form1"].Controls["txtLog"] as System.Windows.Forms.TextBox;
            txtLogs.Text = "";
        }

        public void EnableGetStatsButton()
        {
            if (isGUI)
            {
                System.Windows.Forms.Button btnGetStats = Application.OpenForms["Form1"].Controls["btnGetStats"] as System.Windows.Forms.Button;
                btnGetStats.Enabled = true;
            }
        }
    }
}
