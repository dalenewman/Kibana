using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement.Records;

namespace Kibana.Models {
    public class KibanaPartRecord : ContentPartRecord {

        [StringLength(255)]
        public virtual string Elasticsearch { get; set; }

        [StringLength(255)]
        public virtual string DefaultRoute { get; set; }

        [StringLength(255)]
        public virtual string KibanaIndex { get; set; }
 
    }
}