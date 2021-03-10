using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Validation;
using static Pentagono.Spock.Module.Annotations.RequiredFieldAttribute;
using DevExpress.ExpressApp.ReportsV2;
using Pentagono.Spock.Module.BusinessObjects;
using Pentagono.Spock.Module.Reports;

namespace Pentagono.Spock.Module {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    public sealed partial class SpockModule : ModuleBase {
        public SpockModule() {
            InitializeComponent();
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            PredefinedReportsUpdater reportUpdater = new PredefinedReportsUpdater(Application, objectSpace, versionFromDB);
            reportUpdater.AddPredefinedReport<QuotationReport>("Reporte de cotización vehicular", typeof(VehicleQuotation), isInplaceReport: true);
            return new ModuleUpdater[] { updater, reportUpdater };
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            foreach (ITypeInfo info in typesInfo.PersistentTypes)
            {
                if (info.Type.Namespace == typeof(BusinessObjects.User).Namespace)
                {
                   ModelNodesGeneratorSettings.SetIdPrefix(info.Type, "Spock_" + info.Type.Name);
                }
            }
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }

        public override void Setup(ApplicationModulesManager moduleManager)
        {
            base.Setup(moduleManager);
            ValidationRulesRegistrator.RegisterRule(moduleManager,
                typeof(RequiredField),
                typeof(IRequiredFieldProperties));
        }

        /*
        protected override IEnumerable<Type> GetDeclaredControllerTypes()
            => new[] {
                typeof(ControlController),
            };
            */
    }
}
