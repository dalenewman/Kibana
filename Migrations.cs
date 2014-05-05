using System;
using System.Data;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.UI.Notify;

namespace Kibana {

    public class Migrations : DataMigrationImpl {

        protected INotifier Notifier { get; set; }
        protected Localizer T { get; set; }
        protected ILogger Logger { get; set; }

        public Migrations(INotifier notifier) {
            Notifier = notifier;
            T = NullLocalizer.Instance;
            Logger = NullLogger.Instance;
        }

        public int Create() {
            try {

                SchemaBuilder.CreateTable("KibanaPartRecord", table => table
                    .ContentPartRecord()
                    .Column("Elasticsearch", DbType.String)
                    .Column("DefaultRoute", DbType.String)
                    .Column("KibanaIndex", DbType.String)
                );

                var kibana = new ContentTypeDefinition("Kibana", "Kibana");
                ContentDefinitionManager.StoreTypeDefinition(kibana);
                ContentDefinitionManager.AlterTypeDefinition("Kibana", cfg => cfg.Creatable()
                    .WithPart("KibanaPart")
                    .WithPart("CommonPart")
                    .WithPart("TitlePart")
                    .WithPart("IdentityPart")
                    .WithPart("ContentPermissionsPart", builder => builder
                        .WithSetting("ContentPermissionsPartSettings.View", "Administrator")
                        .WithSetting("ContentPermissionsPartSettings.Publish", "Administrator")
                        .WithSetting("ContentPermissionsPartSettings.Edit", "Administrator")
                        .WithSetting("ContentPermissionsPartSettings.Delete", "Administrator")
                        .WithSetting("ContentPermissionsPartSettings.DisplayedRoles", "Administrator,Authenticated")
                    )
                );

            } catch (Exception e) {
                var message = string.Format("Error creating Kibana module. {0}", e.Message);
                Logger.Warning(message);
                Notifier.Warning(T(message));
                return 0;
            }
            return 1;
        }
    }
}