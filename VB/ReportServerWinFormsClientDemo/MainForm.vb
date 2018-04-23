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
			Task.Factory.StartNew(Of Boolean)(AddressOf Login).ContinueWith(AddressOf LoginCompleted, New CancellationToken(), TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext())
		End Sub

		Private Sub reportListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles reportListBox.SelectedIndexChanged
			showReportButton.Enabled = reportListBox.SelectedItem IsNot Nothing
		End Sub

		Private Sub showReportButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showReportButton.Click
			Dim selectedItem As ReportListBoxItem = CType(reportListBox.SelectedItem, ReportListBoxItem)
			Dim form As New ReportViewerForm(selectedItem.Id) With {.Owner = Me}
			form.ShowDialog()
		End Sub

		Private Function Login() As Boolean
			splashScreenManager1.ShowWaitForm()

			Dim channelFactory As New ChannelFactory(Of IAuthenticationService)("ReportServer_Authentication")
			Dim client As IAuthenticationService = channelFactory.CreateChannel()
			Return client.Login(Nothing, Nothing)
		End Function

		Private Sub LoginCompleted(ByVal task As Task(Of Boolean))
			If task.IsFaulted Then
				splashScreenManager1.CloseWaitForm()
				MessageBox.Show(task.Exception.InnerException.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			If (Not task.Result) Then
				splashScreenManager1.CloseWaitForm()
				MessageBox.Show("Access denied", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			FillReportListBox()
		End Sub

		Private Sub FillReportListBox()
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
	End Class
End Namespace
