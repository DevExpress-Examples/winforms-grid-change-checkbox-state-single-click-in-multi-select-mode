Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors
Imports DevExpress.Utils

Namespace WindowsApplication1

    Public Partial Class Form1
        Inherits Form

        Private Function CreateTable(ByVal RowCount As Integer) As DataTable
            Dim tbl As DataTable = New DataTable()
            tbl.Columns.Add("Name", GetType(String))
            tbl.Columns.Add("ID", GetType(Integer))
            tbl.Columns.Add("Number", GetType(Integer))
            tbl.Columns.Add("Date", GetType(Date))
            tbl.Columns.Add("CheckEdit", GetType(Boolean))
            For i As Integer = 0 To RowCount - 1
                tbl.Rows.Add(New Object() {String.Format("Name{0}", i), i, 3 - i, Date.Now.AddDays(i), i Mod 3 = 0})
            Next

            Return tbl
        End Function

        Public Sub New()
            InitializeComponent()
            gridControl1.DataSource = CreateTable(20)
        End Sub

        Private Sub gridView1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            Dim hitInfo As GridHitInfo = gridView1.CalcHitInfo(e.Location)
            If hitInfo.InRowCell Then
                If TypeOf hitInfo.Column.RealColumnEdit Is RepositoryItemCheckEdit Then
                    gridView1.FocusedColumn = hitInfo.Column
                    gridView1.FocusedRowHandle = hitInfo.RowHandle
                    gridView1.ShowEditor()
                    Dim edit As CheckEdit = TryCast(gridView1.ActiveEditor, CheckEdit)
                    If edit Is Nothing Then Return
                    edit.Toggle()
                    DXMouseEventArgs.GetMouseArgs(e).Handled = True
                End If
            End If
        End Sub
    End Class
End Namespace
