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

Imports System.Windows.Forms
Imports DevExpress.ReportServer.Printing
Imports DevExpress.ReportServer.ServiceModel.ConnectionProviders
Imports DevExpress.ReportServer.ServiceModel.DataContracts

Namespace ReportServerWinFormsClientDemo
    Partial Public Class ReportViewerForm
        Inherits Form

        Private ReadOnly serverConnection As ConnectionProvider

        Public Sub New(ByVal reportId As Integer, ByVal serverConnection As ConnectionProvider)
            InitializeComponent()
            Me.serverConnection = serverConnection
            remoteDocumentSource1.ReportIdentity = New ReportIdentity(reportId)
            AddHandler remoteDocumentSource1.ReportServiceClientDemanded, AddressOf remoteDocumentSource1_ReportServiceClientDemanded
        End Sub

        Private Sub remoteDocumentSource1_ReportServiceClientDemanded(ByVal sender As Object, ByVal e As ReportServiceClientDemandedEventArgs)
            e.Client = serverConnection.CreateClient()
        End Sub
    End Class
End Namespace
