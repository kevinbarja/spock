using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;
using Pentagono.Spock.Module.BusinessObjects;
using System;
using System.Linq;

namespace Pentagono.Spock.Module.Web.Controllers
{
    public class GridLookupController : ViewController<DetailView>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            bool IsAdministrative = (SecuritySystem.CurrentUser as User).IsAdministrative;
            Frame.GetController<DeleteObjectsViewController>().Active["OnlyActiveForAdmin"] = IsAdministrative;
            foreach (ASPxGridLookupPropertyEditor propertyEditor in View.GetItems<ASPxGridLookupPropertyEditor>())
            {
                propertyEditor.ControlCreated += PropertyEditor_ControlCreated;
            }
        }

        protected override void OnDeactivated()
        {
            foreach (ASPxGridLookupPropertyEditor propertyEditor in View.GetItems<ASPxGridLookupPropertyEditor>())
            {
                propertyEditor.ControlCreated -= PropertyEditor_ControlCreated;
            }
            base.OnDeactivated();
        }

        private void PropertyEditor_ControlCreated(object sender, EventArgs args)
        {
            ASPxGridLookupPropertyEditor editor = (ASPxGridLookupPropertyEditor)sender;
            if (editor.Editor != null)
            {
                ASPxGridView gridView = editor.Editor.GridView;
                gridView.Settings.ShowFilterRow = true;
                foreach (GridViewColumn column in gridView.Columns)
                {
                    var columnWithInfo = column as GridViewDataColumn;
                    if (columnWithInfo != null)
                    {
                        GridViewDataColumnInfo columnInfo = ((IDataItemTemplateInfoProvider)editor.GridListEditor).GetColumnInfo(column) as GridViewDataColumnInfo;
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
