namespace ReportServerWinFormsClientDemo
{
    partial class MainForm
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
            this.showReportButton = new System.Windows.Forms.Button();
            this.reportListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ReportServerWinFormsClientDemo.WaitForm1), true, true);
            this.SuspendLayout();
            // 
            // showReportButton
            // 
            this.showReportButton.Enabled = false;
            this.showReportButton.Location = new System.Drawing.Point(657, 527);
            this.showReportButton.Name = "showReportButton";
            this.showReportButton.Size = new System.Drawing.Size(115, 23);
            this.showReportButton.TabIndex = 0;
            this.showReportButton.Text = "Show Report";
            this.showReportButton.UseVisualStyleBackColor = true;
            this.showReportButton.Click += new System.EventHandler(this.showReportButton_Click);
            // 
            // reportListBox
            // 
            this.reportListBox.DisplayMember = "DisplayName";
            this.reportListBox.FormattingEnabled = true;
            this.reportListBox.Location = new System.Drawing.Point(12, 25);
            this.reportListBox.Name = "reportListBox";
            this.reportListBox.Size = new System.Drawing.Size(760, 485);
            this.reportListBox.TabIndex = 1;
            this.reportListBox.SelectedIndexChanged += new System.EventHandler(this.reportListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available reports";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportListBox);
            this.Controls.Add(this.showReportButton);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button showReportButton;
        private System.Windows.Forms.ListBox reportListBox;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}

