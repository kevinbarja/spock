using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;
using Pentagono.Spock.Module.BusinessObjects;

namespace Pentagono.Spock.Module.Web.Controllers
{
    public class GridListController : ViewController<ListView>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            bool IsAdministrative = (SecuritySystem.CurrentUser as User).IsAdministrative;
            Frame.GetController<DeleteObjectsViewController>().Active["OnlyActiveForAdmin"] = IsAdministrative;
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            if (!(View.Editor is ASPxGridListEditor)) return;
            ASPxGridListEditor gridListEditor = View.Editor as ASPxGridListEditor;
            ASPxGridView gridView = gridListEditor.Grid;
            if (gridView != null)
            {
                gridView.Settings.ShowFilterRow = true;
                ((IModelListViewShowAutoFilterRow)View.Model).ShowAutoFilterRow = gridView.Settings.ShowFilterRow;
                foreach (GridViewColumn column in gridView.Columns)
                {
                    var columnWithInfo = column as GridViewDataColumn;
                    if (columnWithInfo != null)
                    {
                        GridViewDataColumnInfo columnInfo = ((IDataItemTemplateInfoProvider)gridListEditor).GetColumnInfo(column) as GridViewDataColumnInfo;
                        Type type = columnInfo.MemberInfo.MemberTypeInfo.Type;
                        if (type.Equals(typeof(string)))
                        {
                            columnWithInfo.Settings.AutoFilterCondition = AutoFilterCondition.Contains;
                        }
                    }
                }
            }
        }
    }
}
