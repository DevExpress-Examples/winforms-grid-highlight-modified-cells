# How to highlight modified cells in grid


<p>This examples illustrates how to highlight modified cells with a background color and bold font. The approach described below is not specific to a data source.<br />Introduce a collection to store GridCell class (it is our class that has the RowHandle and Column properties) instances and populate it when a cell value is changed. The best place for it is the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsBaseColumnView_CellValueChangedtopic">ColumnView.CellValueChanged</a> event handler.<br />The main idea is to change the cell appearance by handling the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsGridGridView_RowCellStyletopic">GridView.RowCellStyle</a> event. Check whether a cell is in this collection in the RowCellStyle event handler and change the cell appearance via the e.Appearance parameter.</p>
<br />
<p>The same approach can be used for other components. The difference is in the events used to customize cell appearance:</p>
 - <strong>TreeList: </strong><a href="https://documentation.devexpress.com/#windowsforms/DevExpressXtraTreeListTreeList_NodeCellStyletopic">TreeList.NodeCellStyle</a>;<br /> - <strong>VerticalGrid</strong> and <strong>PropertyGridControl: </strong><a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraVerticalGridVGridControlBase_RecordCellStyletopic">RecordCellStyle</a>;<br /> - <strong>LayoutView: </strong><a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraGridViewsLayoutLayoutView_CustomFieldValueStyletopic">LayoutView.CustomFieldValueStyle</a>.<br /><br /><br /><strong>See also:</strong> <a href="https://www.devexpress.com/Support/Center/p/E997">How to color a modified cells' in the GridView</a> (for DataTable)<br /><a href="https://www.devexpress.com/Support/Center/p/E1885">How to highlight LayoutView's fields whose values are modified in the data source</a>

<br/>


