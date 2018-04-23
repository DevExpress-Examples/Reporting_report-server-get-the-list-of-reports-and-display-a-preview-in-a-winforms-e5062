// Developer Express Code Central Example:
// How to get the list of available reports, export to PDF and display a report preview in a Windows Forms application
// 
// The sample demonstrates how to use the Report Server WCF API in a Windows Forms
// application.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E5062

// Developer Express Code Central Example:
// How to connect to a Report Server from a Windows Forms application
// 
// The sample demonstrates how to use the Report Server WCF API in a Windows Forms
// application.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E5062

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
            this.export2PDFReportButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
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
            // export2PDFReportButton
            // 
            this.export2PDFReportButton.Enabled = false;
            this.export2PDFReportButton.Location = new System.Drawing.Point(500, 527);
            this.export2PDFReportButton.Name = "export2PDFReportButton";
            this.export2PDFReportButton.Size = new System.Drawing.Size(115, 23);
            this.export2PDFReportButton.TabIndex = 3;
            this.export2PDFReportButton.Text = "Export to PDF";
            this.export2PDFReportButton.UseVisualStyleBackColor = true;
            this.export2PDFReportButton.Click += new System.EventHandler(this.export2PDFReportButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "pdf";
            this.saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.export2PDFReportButton);
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
        private System.Windows.Forms.Button export2PDFReportButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

