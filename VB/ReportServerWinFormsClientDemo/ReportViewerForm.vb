Imports Microsoft.VisualBasic
Imports DevExpress.ReportServer.Printing
Imports DevExpress.ReportServer.ServiceModel.DataContracts
Imports System.Windows.Forms

Namespace ReportServerWinFormsClientDemo
	Partial Public Class ReportViewerForm
		Inherits Form
		Public Sub New(ByVal reportId As Integer)
			InitializeComponent()
			remoteDocumentSource1.ReportIdentity = New ReportIdentity(reportId)
			AddHandler remoteDocumentSource1.ReportServerCredentialsDemanded, AddressOf remoteDocumentSource1_ReportServerCredentialsDemanded ' B250735 workaround
		End Sub

		Private Sub remoteDocumentSource1_ReportServerCredentialsDemanded(ByVal sender As Object, ByVal e As CredentialsEventArgs)
			e.Handled = True
		End Sub
	End Class
End Namespace
