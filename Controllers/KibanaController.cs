using System.Web.Mvc;
using Kibana.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Localization;

namespace KIbana.Controllers {

    public class KibanaController : Controller {

        protected Localizer T { get; set; }
        private readonly IOrchardServices _services;

        public KibanaController(IOrchardServices services) {
            _services = services;
            T = NullLocalizer.Instance;
        }

        public ActionResult Index(int kibanaId) {
            var kibana = _services.ContentManager.Get(kibanaId).As<KibanaPart>();

            if (kibana == null) {
                return new HttpNotFoundResult();
            }

            if (!User.Identity.IsAuthenticated) {
                System.Web.Security.FormsAuthentication.RedirectToLoginPage(Request.RawUrl);
            }

            if (!_services.Authorizer.Authorize(Orchard.Core.Contents.Permissions.ViewContent, kibana, T("Permission to this Kibana (Dashboard) is denied."))) {
                return new HttpUnauthorizedResult();
            }

            return View("Index", kibana);
        }

    }

}