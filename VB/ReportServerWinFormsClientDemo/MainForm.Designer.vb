Imports Microsoft.VisualBasic
Imports System
Namespace ReportServerWinFormsClientDemo
	Partial Public Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.showReportButton = New System.Windows.Forms.Button()
			Me.reportListBox = New System.Windows.Forms.ListBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.splashScreenManager1 = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.ReportServerWinFormsClientDemo.WaitForm1), True, True)
			Me.SuspendLayout()
			' 
			' showReportButton
			' 
			Me.showReportButton.Enabled = False
			Me.showReportButton.Location = New System.Drawing.Point(657, 527)
			Me.showReportButton.Name = "showReportButton"
			Me.showReportButton.Size = New System.Drawing.Size(115, 23)
			Me.showReportButton.TabIndex = 0
			Me.showReportButton.Text = "Show Report"
			Me.showReportButton.UseVisualStyleBackColor = True
'			Me.showReportButton.Click += New System.EventHandler(Me.showReportButton_Click);
			' 
			' reportListBox
			' 
			Me.reportListBox.DisplayMember = "DisplayName"
			Me.reportListBox.FormattingEnabled = True
			Me.reportListBox.Location = New System.Drawing.Point(12, 25)
			Me.reportListBox.Name = "reportListBox"
			Me.reportListBox.Size = New System.Drawing.Size(760, 485)
			Me.reportListBox.TabIndex = 1
'			Me.reportListBox.SelectedIndexChanged += New System.EventHandler(Me.reportListBox_SelectedIndexChanged);
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(85, 13)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Available reports"
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(784, 562)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.reportListBox)
			Me.Controls.Add(Me.showReportButton)
			Me.Name = "MainForm"
			Me.Text = "Main Form"
'			Me.Load += New System.EventHandler(Me.MainForm_Load);
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private WithEvents showReportButton As System.Windows.Forms.Button
		Private WithEvents reportListBox As System.Windows.Forms.ListBox
		Private label1 As System.Windows.Forms.Label
		Private splashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
	End Class
End Namespace

