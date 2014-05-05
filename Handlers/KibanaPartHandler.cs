using System.Web.Routing;
using Kibana.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Kibana.Handlers {
    public class KibanaPartHandler : ContentHandler {

        public KibanaPartHandler(IRepository<KibanaPartRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }

        protected override void GetItemMetadata(GetContentItemMetadataContext context) {
            var kibana = context.ContentItem.As<KibanaPart>();

            if (kibana == null)
                return;

            base.GetItemMetadata(context);
            context.Metadata.DisplayRouteValues = new RouteValueDictionary {
                {"Area", "Kibana"},
                {"Controller", "Kibana"},
                {"Action", "Index"},
                {"kibanaId", context.ContentItem.Id}
            };
        }
    }
}
