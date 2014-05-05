using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Kibana {

    public class Routes : IRouteProvider {

        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                new RouteDescriptor {
                    Priority = 11,
                    Route = new Route(
                        "Modules/Kibana/{kibanaId}",
                        new RouteValueDictionary { {"area", "Kibana"}, {"controller", "Kibana"}, {"action", "Index"} },
                        new RouteValueDictionary(),
                        new RouteValueDictionary { {"area", "Kibana"} },
                        new MvcRouteHandler()
                    )
                }
            };
        }
    }
}