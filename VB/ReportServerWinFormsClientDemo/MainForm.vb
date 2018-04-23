Imports Microsoft.VisualBasic
Imports DevExpress.Data.Utils.ServiceModel
Imports DevExpress.ReportServer.ServiceModel.Client
Imports DevExpress.ReportServer.ServiceModel.DataContracts
Imports System
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace ReportServerWinFormsClientDemo
	Partial Public Class MainForm
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Login()
		End Sub

		Private Sub Login()
			splashScreenManager1.ShowWaitForm()
			Dim authenticationClientFactory As New AuthenticationServiceClientFactory("ReportServer_Authentication")
			Dim authenticationClient = authenticationClientFactory.Create()
			authenticationClient.Login(Nothing, Nothing, Nothing, AddressOf LoginCompleted)
		End Sub

		Private Sub LoginCompleted(ByVal args As ScalarOperationCompletedEventArgs(Of Boolean))
			splashScreenManager1.CloseWaitForm()
			If args.Error IsNot Nothing Then
				MessageBox.Show(args.Error.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If
			If (Not args.Result) Then
				MessageBox.Show("Access denied", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If
			FillReportListBox()
		End Sub

		Private Sub FillReportListBox()
			splashScreenManager1.ShowWaitForm()
			Dim factory As New ReportServerClientFactory("ReportServer")
			Dim client As IReportServerClient = factory.Create()
			client.GetReports(Nothing, AddressOf GetReportsCompletedCallback)
		End Sub

		Private Sub GetReportsCompletedCallback(ByVal args As ScalarOperationCompletedEventArgs(Of IEnumerable(Of ReportCatalogItemDto)))
			splashScreenManager1.CloseWaitForm()

			If args.Error IsNot Nothing Then
				MessageBox.Show(args.Error.Message)
				Return
			End If

			For Each reportDto In args.Result
				Dim listBoxItem As New ReportListBoxItem() With {.DisplayName = reportDto.Name, .Id = reportDto.Id}
				reportListBox.Items.Add(listBoxItem)
			Next reportDto
		End Sub

		Private Sub reportListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles reportListBox.SelectedIndexChanged
			showReportButton.Enabled = reportListBox.SelectedItem IsNot Nothing
		End Sub

		Private Sub showReportButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showReportButton.Click
			Dim selectedItem As ReportListBoxItem = CType(reportListBox.SelectedItem, ReportListBoxItem)
			Dim form As New ReportViewerForm(selectedItem.Id) With {.Owner = Me}
			form.ShowDialog()
		End Sub
	End Class
End Namespace
