
namespace FXP_Statistics
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblForumNum = new System.Windows.Forms.Label();
            this.txtForumNum = new System.Windows.Forms.TextBox();
            this.btnGetStats = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtNumOfDays = new System.Windows.Forms.TextBox();
            this.lblDaysGoBack = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblForumNum
            // 
            this.lblForumNum.AutoSize = true;
            this.lblForumNum.Location = new System.Drawing.Point(13, 18);
            this.lblForumNum.Name = "lblForumNum";
            this.lblForumNum.Size = new System.Drawing.Size(139, 25);
            this.lblForumNum.TabIndex = 0;
            this.lblForumNum.Text = "Forum number";
            // 
            // txtForumNum
            // 
            this.txtForumNum.Location = new System.Drawing.Point(158, 16);
            this.txtForumNum.Name = "txtForumNum";
            this.txtForumNum.Size = new System.Drawing.Size(344, 29);
            this.txtForumNum.TabIndex = 1;
            this.txtForumNum.Text = "10122";
            // 
            // btnGetStats
            // 
            this.btnGetStats.Location = new System.Drawing.Point(520, 7);
            this.btnGetStats.Name = "btnGetStats";
            this.btnGetStats.Size = new System.Drawing.Size(164, 46);
            this.btnGetStats.TabIndex = 2;
            this.btnGetStats.Text = "Get Stats";
            this.btnGetStats.UseVisualStyleBackColor = true;
            this.btnGetStats.Click += new System.EventHandler(this.btnGetStats_Click);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(946, 510);
            this.txtLog.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtNumOfDays);
            this.splitContainer1.Panel1.Controls.Add(this.lblDaysGoBack);
            this.splitContainer1.Panel1.Controls.Add(this.lblForumNum);
            this.splitContainer1.Panel1.Controls.Add(this.txtForumNum);
            this.splitContainer1.Panel1.Controls.Add(this.btnGetStats);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtLog);
            this.splitContainer1.Size = new System.Drawing.Size(946, 576);
            this.splitContainer1.SplitterDistance = 62;
            this.splitContainer1.TabIndex = 4;
            // 
            // txtNumOfDays
            // 
            this.txtNumOfDays.Location = new System.Drawing.Point(179, 61);
            this.txtNumOfDays.Name = "txtNumOfDays";
            this.txtNumOfDays.Size = new System.Drawing.Size(324, 29);
            this.txtNumOfDays.TabIndex = 4;
            // 
            // lblDaysGoBack
            // 
            this.lblDaysGoBack.AutoSize = true;
            this.lblDaysGoBack.Location = new System.Drawing.Point(13, 63);
            this.lblDaysGoBack.Name = "lblDaysGoBack";
            this.lblDaysGoBack.Size = new System.Drawing.Size(160, 25);
            this.lblDaysGoBack.TabIndex = 3;
            this.lblDaysGoBack.Text = "Number of days: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 576);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "FXP Statistics";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblForumNum;
        private System.Windows.Forms.TextBox txtForumNum;
        private System.Windows.Forms.Button btnGetStats;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtNumOfDays;
        private System.Windows.Forms.Label lblDaysGoBack;
    }
}

