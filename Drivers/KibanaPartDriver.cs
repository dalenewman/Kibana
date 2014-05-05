using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Kibana.Models;

namespace Kibana.Drivers {
    public class KibanaPartDriver : ContentPartDriver<KibanaPart> {

        protected override string Prefix {
            get { return "Kibana"; }
        }

        //GET
        protected override DriverResult Editor(KibanaPart part, dynamic shapeHelper) {
            return ContentShape("Parts_Kibana_Edit", () => shapeHelper
                .EditorTemplate(TemplateName: "Parts/Kibana", Model: part, Prefix: Prefix));
        }

        //POST
        protected override DriverResult Editor(KibanaPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        protected override DriverResult Display(KibanaPart part, string displayType, dynamic shapeHelper) {

            if (displayType.StartsWith("Summary")) {
                return Combined(
                    ContentShape("Parts_Kibana_SummaryAdmin", () => shapeHelper.Parts_Kibana_SummaryAdmin(Part: part))
                );
            }

            return null;
        }


    }
}
