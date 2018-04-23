' Developer Express Code Central Example:
' How to get the list of available reports, export to PDF and display a report preview in a Windows Forms application
' 
' The sample demonstrates how to use the Report Server WCF API in a Windows Forms
' application.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E5062

' Developer Express Code Central Example:
' How to connect to a Report Server from a Windows Forms application
' 
' The sample demonstrates how to use the Report Server WCF API in a Windows Forms
' application.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E5062

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
            Me.export2PDFReportButton = New System.Windows.Forms.Button()
            Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
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
            ' 
            ' reportListBox
            ' 
            Me.reportListBox.DisplayMember = "DisplayName"
            Me.reportListBox.FormattingEnabled = True
            Me.reportListBox.Location = New System.Drawing.Point(12, 25)
            Me.reportListBox.Name = "reportListBox"
            Me.reportListBox.Size = New System.Drawing.Size(760, 485)
            Me.reportListBox.TabIndex = 1
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
            ' export2PDFReportButton
            ' 
            Me.export2PDFReportButton.Enabled = False
            Me.export2PDFReportButton.Location = New System.Drawing.Point(500, 527)
            Me.export2PDFReportButton.Name = "export2PDFReportButton"
            Me.export2PDFReportButton.Size = New System.Drawing.Size(115, 23)
            Me.export2PDFReportButton.TabIndex = 3
            Me.export2PDFReportButton.Text = "Export to PDF"
            Me.export2PDFReportButton.UseVisualStyleBackColor = True
            ' 
            ' saveFileDialog1
            ' 
            Me.saveFileDialog1.DefaultExt = "pdf"
            Me.saveFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"
            ' 
            ' MainForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 562)
            Me.Controls.Add(Me.export2PDFReportButton)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.reportListBox)
            Me.Controls.Add(Me.showReportButton)
            Me.Name = "MainForm"
            Me.Text = "Main Form"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private WithEvents showReportButton As System.Windows.Forms.Button
        Private WithEvents reportListBox As System.Windows.Forms.ListBox
        Private label1 As System.Windows.Forms.Label
        Private splashScreenManager1 As DevExpress.XtraSplashScreen.SplashScreenManager
        Private WithEvents export2PDFReportButton As System.Windows.Forms.Button
        Private saveFileDialog1 As System.Windows.Forms.SaveFileDialog
    End Class
End Namespace

