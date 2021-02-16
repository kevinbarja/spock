using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using Pentagono.Spock.Module.BusinessObjects;
using System;
namespace Pentagono.Spock.Module.Web.Editors
{
    [PropertyEditor(typeof(IGridLookup), true)]
    public class GridLookupPropertyEditor : ASPxGridLookupPropertyEditor
    {
        public GridLookupPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
        {

        }
    }
}
