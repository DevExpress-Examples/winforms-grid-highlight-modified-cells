Imports Microsoft.VisualBasic
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Windows.Forms

Namespace dxExample
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			gridControl1.DataSource = GetData(10)
			AddHandler gridView1.RowCellStyle, AddressOf gridView1_RowCellStyle
			AddHandler gridView1.CellValueChanged, AddressOf gridView1_CellValueChanged
		End Sub

		Private modifiedCells As New List(Of GridCell)()
		Private Function CellExists(ByVal sourceRowIndex As Integer, ByVal col As GridColumn) As Boolean
			Dim existingCell As GridCell = modifiedCells.Where(Function(c) c.Column Is col AndAlso c.RowHandle = sourceRowIndex).FirstOrDefault()
			Return existingCell IsNot Nothing
		End Function

		Private Sub gridView1_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
			If (Not CellExists(gridView1.GetDataSourceRowIndex(e.RowHandle), e.Column)) Then
				modifiedCells.Add(New GridCell(gridView1.GetDataSourceRowIndex(e.RowHandle), e.Column))
			End If
		End Sub

		Private Sub gridView1_RowCellStyle(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs)
			If CellExists(gridView1.GetDataSourceRowIndex(e.RowHandle), e.Column) Then
				e.Appearance.BackColor = Color.ForestGreen
				e.Appearance.BackColor2 = Color.LimeGreen
				e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
			End If
		End Sub

		Private Function GetData(ByVal rows As Integer) As DataTable
			Dim dt As New DataTable()
			dt.Columns.Add("ID", GetType(Integer))
			dt.Columns.Add("Info", GetType(String))
			For i As Integer = 0 To rows - 1
				dt.Rows.Add(i, "Info" & i)
			Next i
			Return dt
		End Function

		Private Sub clearButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearButton.Click
			modifiedCells.Clear()
			gridView1.LayoutChanged()
		End Sub
	End Class
End Namespace
