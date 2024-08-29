<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128629243/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T190692)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - Highlight modified cells

> **Note**
> 
> In v19.1+, you can use the [FormatConditionRuleDataUpdate class](https://docs.devexpress.com/WindowsForms/DevExpress.XtraEditors.FormatConditionRuleDataUpdate) to highlight a cell with a custom icon and/or appearance settings for a limited time when a cell value changes in GridView, BandedGridView, and AdvBandedGridView. [Example](https://docs.devexpress.com/WindowsForms/400738/controls-and-libraries/data-grid/examples/conditional-formatting/how-to-temporarily-highlight-a-cell-when-a-value-changes)

This example shows how to highlight modified cells.

Once the user changes a cell's value, the cell is added to the `modifiedCells` collection:

```csharp
List<GridCell> modifiedCells = new List<GridCell>();
void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) {
    if (!CellExists(gridView1.GetDataSourceRowIndex(e.RowHandle), e.Column)){
        modifiedCells.Add(new GridCell(gridView1.GetDataSourceRowIndex(e.RowHandle), e.Column));
	}
}
```

The [RowCellStyle](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.RowCellStyle) event is handled to customize the appearance (background and foreground colors) of modified cells:

```csharp
void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e) {
    if (CellExists(gridView1.GetDataSourceRowIndex(e.RowHandle), e.Column)) {
        e.Appearance.BackColor = Color.ForestGreen;
        e.Appearance.BackColor2 = Color.LimeGreen;
        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
	}
}
bool CellExists(int sourceRowIndex, GridColumn col) {
    GridCell existingCell = modifiedCells.Where(c => c.Column == col && c.RowHandle == sourceRowIndex).FirstOrDefault();
    return existingCell != null;
}
```


## Files to Review

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))


## Documentation

* [Appearance and Conditional Formatting](https://docs.devexpress.com/WindowsForms/115548/controls-and-libraries/data-grid/appearance-and-conditional-formatting)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-highlight-modified-cells&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-highlight-modified-cells&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
