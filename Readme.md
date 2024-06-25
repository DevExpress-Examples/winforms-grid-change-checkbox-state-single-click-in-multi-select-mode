<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128625904/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2166)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - Change the state of a checkbox with a single click (multi-select mode)

This example shows how to handle the `MouseDown` event in Grid View so that users can change the state of a checkbox with a single click. In this example, the [OptionsSelection.MultiSelectMode](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridOptionsSelection.MultiSelectMode) property is set to `GridMultiSelectMode.CellSelect`.

```csharp
private void gridView1_MouseDown(object sender, MouseEventArgs e) {
    GridHitInfo hitInfo = gridView1.CalcHitInfo(e.Location);
    if (hitInfo.InRowCell) {
        if (hitInfo.Column.RealColumnEdit is RepositoryItemCheckEdit) {
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
```


## Files to Review

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))


## Documentation

* [Multiple Row and Cell Selection](https://docs.devexpress.com/WindowsForms/711/controls-and-libraries/data-grid/focus-and-selection-handling/multiple-row-and-cell-selection)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-change-checkbox-state-single-click-in-multi-select-mode&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-change-checkbox-state-single-click-in-multi-select-mode&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
