using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace dxExample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            gridControl1.DataSource = GetData(10);
            gridView1.RowCellStyle += gridView1_RowCellStyle;
            gridView1.CellValueChanged += gridView1_CellValueChanged;
        }

        List<GridCell> modifiedCells = new List<GridCell>();
        bool CellExists(int sourceRowIndex, GridColumn col) {
			GridCell existingCell = modifiedCells.Where(c => c.Column == col && c.RowHandle == sourceRowIndex).FirstOrDefault();
            return existingCell != null;
		}

        void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) {
            if (!CellExists(gridView1.GetDataSourceRowIndex(e.RowHandle), e.Column)){
                modifiedCells.Add(new GridCell(gridView1.GetDataSourceRowIndex(e.RowHandle), e.Column));
			}
        }

        void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e) {
            if (CellExists(gridView1.GetDataSourceRowIndex(e.RowHandle), e.Column)) {
                e.Appearance.BackColor = Color.ForestGreen;
                e.Appearance.BackColor2 = Color.LimeGreen;
                e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
			}
        }

        DataTable GetData(int rows) {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Info", typeof(string));
            for (int i = 0; i < rows; i++)
                dt.Rows.Add(i, "Info" + i);
            return dt;
        }

        private void clearButton_Click(object sender, EventArgs e) {
            modifiedCells.Clear();
            gridView1.LayoutChanged();
        }
    }
}
