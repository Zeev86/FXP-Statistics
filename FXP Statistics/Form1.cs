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
        //public Parser parser = new Parser();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnGetStats_Click(object sender, EventArgs e)
        {
            btnGetStats.Enabled = false;
            Parser parser = new Parser();
            parser.GetForumThreads(txtForumNum.Text, 1);
        }
    }
}
