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
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace ReportServerWinFormsClientDemo
    Friend NotInheritable Class Program

        Private Sub New()
        End Sub

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())
        End Sub
    End Class
End Namespace
