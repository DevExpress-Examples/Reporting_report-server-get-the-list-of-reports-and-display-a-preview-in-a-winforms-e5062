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
		End Sub
	End Class
End Namespace
