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

Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.DocumentServices.ServiceModel
Imports DevExpress.ReportServer.ServiceModel.Client
Imports DevExpress.ReportServer.ServiceModel.ConnectionProviders
Imports DevExpress.ReportServer.ServiceModel.DataContracts
Imports DevExpress.XtraPrinting

Namespace ReportServerWinFormsClientDemo
    Partial Public Class MainForm
        Inherits Form

        Private Const ServerAddress As String = "https://reportserver.devexpress.com"
        Private ReadOnly serverConnection As ConnectionProvider = New GuestConnectionProvider(ServerAddress)

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Dim uiContext As SynchronizationContext = SynchronizationContext.Current
            splashScreenManager1.ShowWaitForm()

            serverConnection.ConnectAsync().ContinueWith(Function(task)
                Dim client As IReportServerClient = task.Result
                client.SetSynchronizationContext(uiContext)
                Return client.GetReportsAsync(Nothing)
            End Function).Unwrap().ContinueWith(Sub(task)
                splashScreenManager1.CloseWaitForm()
                If task.IsFaulted Then
                    MessageBox.Show(task.Exception.Flatten().InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    FillReportListBox(task.Result)
                End If
End Sub, TaskScheduler.FromCurrentSynchronizationContext())
        End Sub

        Private Sub FillReportListBox(ByVal reports As IEnumerable(Of ReportCatalogItemDto))
            For Each reportDto In reports
                Dim listBoxItem As New ReportListBoxItem() With {.DisplayName = reportDto.Name, .Id = reportDto.Id}
                reportListBox.Items.Add(listBoxItem)
            Next reportDto
        End Sub

        Private Sub reportListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles reportListBox.SelectedIndexChanged
            showReportButton.Enabled = reportListBox.SelectedItem IsNot Nothing
            export2PDFReportButton.Enabled = reportListBox.SelectedItem IsNot Nothing
        End Sub

        Private Sub showReportButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showReportButton.Click
            Dim selectedItem As ReportListBoxItem = DirectCast(reportListBox.SelectedItem, ReportListBoxItem)
            Dim form As New ReportViewerForm(selectedItem.Id, serverConnection) With {.Owner = Me}
            form.ShowDialog()
        End Sub

        Private Sub ExportToPdf(ByVal serverConnection As ConnectionProvider, ByVal fileName As String, ByVal reportId As Integer)
            splashScreenManager1.ShowWaitForm()
            Task.Factory.ExportReportAsync(serverConnection.CreateClient(), New ReportIdentity(reportId), New PdfExportOptions(), Nothing, Nothing).ContinueWith(Sub(task)
                splashScreenManager1.CloseWaitForm()
                Try
                    If task.IsFaulted Then
                        Throw New Exception(task.Exception.Flatten().InnerException.Message)
                    End If
                    File.WriteAllBytes(fileName, task.Result)
                Catch e As Exception
                    MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Sub, TaskScheduler.FromCurrentSynchronizationContext())
        End Sub

        Private Sub export2PDFReportButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles export2PDFReportButton.Click
            If saveFileDialog1.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
                Return
            End If
            ExportToPdf(serverConnection, saveFileDialog1.FileName, DirectCast(reportListBox.SelectedItem, ReportListBoxItem).Id)
        End Sub
    End Class
End Namespace
