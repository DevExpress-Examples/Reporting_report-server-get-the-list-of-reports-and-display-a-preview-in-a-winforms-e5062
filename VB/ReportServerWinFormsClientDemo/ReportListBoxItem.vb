Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace ReportServerWinFormsClientDemo
	Public Class ReportListBoxItem
		Private privateDisplayName As String
		Public Property DisplayName() As String
			Get
				Return privateDisplayName
			End Get
			Set(ByVal value As String)
				privateDisplayName = value
			End Set
		End Property
		Private privateId As Integer
		Public Property Id() As Integer
			Get
				Return privateId
			End Get
			Set(ByVal value As Integer)
				privateId = value
			End Set
		End Property
	End Class
End Namespace
