
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
            this.txtLog.Location = new System.Drawing.Point(14, 73);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(762, 362);
            this.txtLog.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnGetStats);
            this.Controls.Add(this.txtForumNum);
            this.Controls.Add(this.lblForumNum);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblForumNum;
        private System.Windows.Forms.TextBox txtForumNum;
        private System.Windows.Forms.Button btnGetStats;
        private System.Windows.Forms.TextBox txtLog;
    }
}

