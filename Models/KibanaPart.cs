using System;
using Orchard.ContentManagement;

namespace Kibana.Models {
    public class KibanaPart : ContentPart<KibanaPartRecord> {

        public string Elasticsearch {
            get { return Record.Elasticsearch; }
            set { Record.Elasticsearch = value; }
        }

        public string DefaultRoute {
            get { return Record.DefaultRoute; }
            set { Record.DefaultRoute = value; }
        }

        public string KibanaIndex {
            get { return Record.KibanaIndex; }
            set { Record.KibanaIndex = value; }
        }

        public bool IsValid() {
            return !String.IsNullOrEmpty(Elasticsearch) && !String.IsNullOrEmpty(KibanaIndex);
        }

    }
}