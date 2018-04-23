using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
                private DataTable CreateTable(int RowCount)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Number", typeof(int));
            tbl.Columns.Add("Date", typeof(DateTime));
            tbl.Columns.Add("CheckEdit", typeof(bool));
            for (int i = 0; i < RowCount; i++)
                tbl.Rows.Add(new object[] { String.Format("Name{0}", i), i, 3 - i, DateTime.Now.AddDays(i), i % 3 == 0 });
            return tbl;
        }
        

        public Form1()
        {
            InitializeComponent();
            gridControl1.DataSource = CreateTable(20);
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = gridView1.CalcHitInfo(e.Location);
            if (hitInfo.InRowCell)
            {
                if (hitInfo.Column.RealColumnEdit is RepositoryItemCheckEdit)
                {
                    gridView1.FocusedColumn = hitInfo.Column;
                    gridView1.FocusedRowHandle = hitInfo.RowHandle;
                    gridView1.ShowEditor();
                    CheckEdit edit = gridView1.ActiveEditor as CheckEdit;
                    if (edit == null) return;
                    edit.Toggle();
                    DXMouseEventArgs.GetMouseArgs(e).Handled = true;
                }
            }
        }
    }
}